/*
 * AA.js (1.0.0)
 *
 * Copyright (c) 2017 Hung.Le (emismith90@gmail.com)
 * Released under the MIT license
 */

(function (window) {
    if (!window) return;

    window.AA = function AtomicApp(name) {
        this.appName = name;
        this.invokeMetadatas = {};

        // dependency resolver
        this.$injector = new DependencyResolver();

        // event aggregator for components
        this.$aquarium = new Aquarium(this.appName, true);

        registerBaseService.apply(this);

        // for 
        // 1. executable func 
        // 2. has no reference to it
        this.run = function (name, array) {
            var isArray = Array.isArray(array);
            if (isArray && array.length == 0) return this;

            var obj = isArray ? array[array.length - 1] : array;

            // metadata
            this.invokeMetadatas[name] = {
                name: name,
                dependencies: isArray ? array.slice(0, array.length - 1) : [],
                obj: obj
            };

            var dependencies = this.$injector.resolveAll(this.invokeMetadatas[name].dependencies);
            if (!dependencies) {
                this.invokeMetadatas[name].$instance = this.invokeMetadatas[name].obj.apply(this);
            }
            else {
                this.invokeMetadatas[name].$instance = this.invokeMetadatas[name].obj.apply(this, dependencies);
            }

            return this;
        };

        // services registration
        this.use = function (name, array) {
            var isArray = Array.isArray(array);
            if (isArray && array.length == 0) return this;

            var obj = isArray ? array[array.length - 1] : array;

            // metadata
            this.$injector.register(name, {
                name: name,
                dependencies: isArray ? array.slice(0, array.length - 1) : [],
                obj: obj
            });

            return this;
        };

        function registerBaseService() {
            var app = this;
            app.$injector.register('$injector', {
                name: '$injector',
                dependencies: [],
                obj: function () { return app.$injector }
            });
            app.$injector.register('$aquarium', {
                name: '$aquarium',
                dependencies: [],
                obj: function () { return app.$aquarium }
            });
        }

        function DependencyResolver() {
            this.serviceMetadatas = {};

            this.register = function (name, metadata) {
                this.serviceMetadatas[name] = metadata;
            }

            this.resolve = function (dependencyName) {
                if (!this.serviceMetadatas[dependencyName]) return null;
                if (!this.serviceMetadatas[dependencyName].$instance) {
                    var dependencies = this.resolveAll(this.serviceMetadatas[dependencyName].dependencies);
                    if (!dependencies) {
                        this.serviceMetadatas[dependencyName].$instance = this.serviceMetadatas[dependencyName].obj.apply(this);
                    }
                    else {
                        this.serviceMetadatas[dependencyName].$instance = this.serviceMetadatas[dependencyName].obj.apply(this, dependencies);
                    }
                }

                return this.serviceMetadatas[dependencyName].$instance;
            };

            this.resolveAll = function (dependencies) {
                var self = this;
                if (dependencies.length == 0) {
                    return null;
                } else {
                    var resolved = [];
                    dependencies.forEach(function (dep) {
                        resolved.push(self.resolve(dep));
                    });

                    return resolved;
                }
            };
        }

        function Aquarium(name, debug) {
            this.fishes = {};
            this.aquariumName = name || (new Date().getTime()).toString(36);
            var enableLog = debug || false;

            this.pet = function () {
                if (arguments.length <= 1) return false;
                var food = arguments[arguments.length - 1];

                for (var i = 0; i < arguments.length - 1; i++) {
                    var fishName = arguments[i];

                    if (enableLog)
                        console.log('Feeding [' + food + '] to [' + fishName + '] at [' + this.aquariumName + ']');

                    if (!this.fishes[fishName]) return;

                    this.fishes[fishName].forEach(function (delivery) {
                        delivery(food);
                    });
                }
            };

            this.whenPet = function () {
                if (arguments.length <= 1) return false;
                var delivery = arguments[arguments.length - 1];

                for (var i = 0; i < arguments.length - 1; i++) {
                    var fishName = arguments[i];
                    if (!this.fishes[fishName]) this.fishes[fishName] = [];

                    this.fishes[fishName].push(delivery);
                }

                return this;
            };
        };
    }
})(window);

////USAGE
//var app = new AtomicApp();

//app.use('jquery', jQuery)
//    .use('serviceA', [function () {
//        return {
//            greeting: function (name) {
//                return 'Hello ' + name;
//            }
//        };
//    }])
//    .use('serviceB', ['serviceA', function (a) {
//        return {
//            print: function () {
//                console.log(a.greeting('Hung.Le'));
//            }
//        }
//    }])
//    .run('main', ['jquery', 'serviceB', function ($$, b) {
//        b.print();
//        if ($$) {
//            // jQuery is loaded  
//            alert("jQuery!");
//        } 
//    }]);