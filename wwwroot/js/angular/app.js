(function (window) {
    'use strict';

    var appDemo = window.appDemo = window.appDemo || {};

    appDemo.modules = {
        app: {
            name: 'app'
        }
    };
}(window));

(function (angular) {
    'use strict';

    angular.module('appDemo', ['ui.router', 'oc.lazyLoad', 'ngCookies', 'ui.bootstrap', 'ngAnimate', 'toaster']);

}(angular));

var app = angular.module(appDemo.modules.app.name, ['appDemo']);

function controllerPath(type, file) {
    var controller = '../js/angular/controllers/';
    if (type) {
        return controller + type + '/' + file + '.js';
    } else {
        return controller + file + '.js';
    }
}

function templatePath(type, file) {
    if (type)
        return '../views/areas/' + type + '/' + file + '.html';
    else
        return '../views/' + file + '.html';
}


app.constant('JS_REQUIRES', {

    //*** Scripts
    scripts: {
        //*** Controllers
        'dashboardCtrl': controllerPath('dashboard', 'dashboardCtrl'),
        'pontosCtrl': controllerPath('pontos', 'pontosCtrl'),
        'resultadoCtrl': controllerPath('resultado', 'resultadoCtrl'),
        'sidebarCtrl': controllerPath('sidebar', 'sidebarCtrl'),

        //*** Filters
        'str-format': '../js/angular/filters/str-format.js',

    },
    //*** angularJS Modules
    modules: [
        
    ]
});
