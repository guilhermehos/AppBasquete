(function (app) {
    'use strict';

    app.config(['$stateProvider', '$controllerProvider', '$compileProvider', '$filterProvider', '$provide', '$ocLazyLoadProvider', 'JS_REQUIRES',
        function ($stateProvider, $controllerProvider, $compileProvider, $filterProvider, $provide, $ocLazyLoadProvider, jsRequires) {

            app.controller = $controllerProvider.register;
            app.directive = $compileProvider.directive;
            app.filter = $filterProvider.register;
            app.factory = $provide.factory;
            app.service = $provide.service;
            app.constant = $provide.constant;
            app.value = $provide.value;

            // LAZY MODULES

            $ocLazyLoadProvider.config({
                debug: false,
                events: true,
                modules: jsRequires.modules
            });

            // APPLICATION ROUTES
            // -----------------------------------
            // For any unmatched url, redirect to /app/dashboard
            //$urlRouterProvider.otherwise("/app/home");


            // Setup
            $stateProvider.state('app', {
                url: "/app",
                templateUrl: templatePath('', 'app'),
                abstract: true,
                access: {
                    requiresLogin: false
                }
            }).state('app.home', {
                url: "/home",
                templateUrl: templatePath('dashboard', 'dashboard'),
                resolve: loadSequence('dashboardCtrl'),
                title: 'DASHBOARD',
                access: {
                    requiresLogin: false
                }
            })

            //Videos
            .state('app.pontos', {
                url: "/pontos",
                templateUrl: templatePath('pontos', 'pontos'),
                resolve: loadSequence('pontosCtrl'),
                title: 'PONTOS',
                access: {
                    requiresLogin: false
                }
            })
            .state('app.resultado', {
                url: "/resultado",
                params: { id: null },
                templateUrl: templatePath('resultado', 'resultado'),
                resolve: loadSequence('resultadoCtrl'),
                title: 'RESULTADO',
                access: {
                    requiresLogin: false
                }
            });

            // Generates a resolve object previously configured in constant.JS_REQUIRES (config.constant.js)
            function loadSequence() {
                var _args = arguments;
                return {
                    deps: ['$ocLazyLoad', '$q',
                        function ($ocLL, $q) {
                            var promise = $q.when(1);
                            for (var i = 0, len = _args.length; i < len; i++) {
                                promise = promiseThen(_args[i]);
                            }
                            return promise;

                            function promiseThen(_arg) {
                                if (typeof _arg === 'function')
                                    return promise.then(_arg);
                                else
                                    return promise.then(function () {
                                        var nowLoadf = requiredData(_arg);

                                        if (!nowLoadf)
                                            return $.error('Route resolve: Bad resource name [' + _arg + ']');

                                        var nowLoad = angular.copy(nowLoadf);

                                        if (Array.isArray(nowLoad))
                                            for (var i = 0; i < nowLoad.length; i++) nowLoad[i];
                                        else if (nowLoad && typeof nowLoad === 'object' && nowLoad.constructor === Object) {
                                            for (var x = 0; x < nowLoad.files.length; x++) nowLoad.files[x];
                                        }
                                        else if (typeof nowLoad === 'string' || nowLoad instanceof String)
                                            nowLoad;

                                        return $ocLL.load(nowLoad)
                                    });
                            }

                            function requiredData(name) {
                                if (jsRequires.modules)
                                    for (var m in jsRequires.modules)
                                        if (jsRequires.modules[m].name && jsRequires.modules[m].name === name)
                                            return jsRequires.modules[m];
                                return jsRequires.scripts && jsRequires.scripts[name];
                            }
                        }
                    ]
                };
            }

            function templatePath(type, file) {
                if (type)
                    return '../views/areas/' + type + '/' + file + '.html';
                else
                    return '../views/' + file + '.html';
            }
        }
    ]);
}(app));