(function (app) {
    'use strict';

    app.factory('UrlService', ['$state', 'UrlBase',
        function ($state, UrlBase) {

            var urlbase = location.origin;
          
            return {
                getAPI: function (controller, id) {
                    var url = urlbase + "/api/" + controller;
                    url = !id ? url : url + "/" + id;
                    return url.replace("#", "");
                },
                getAPIAction: function (controller, action, id) {
                    var url = urlbase + "/api/" + controller + "/" + action;
                    url = !id ? url : url + "/" + id;
                    return url.replace("#", "");
                },
                getUrl: function (controller, action, hash) {
                    var url = UrlBase.get() + controller + "/" + action;
                    if (hash)
                        return url;
                    else
                        return url.replace("#", "");
                },
                redirect: function (controller, action) {
                    var url = urlbase + "/#/" + controller;
                    if (action) {
                        url += "/" + action;
                    }
                    window.location = url;
                },
                redirectBlank: function (controller, action) {
                    var url = urlbase + "/#/" + controller;
                    if (action) {
                        url += "/" + action;
                    }
                    window.open(url, "_blank");
                },
                redirectHome: function () {
                    var controller = "app";
                    var action = "home";

                    var url = urlbase + "/#/" + controller;
                    if (action) {
                        url += "/" + action;
                    }

                    window.location = url;
                },
                reload: function () {
                    $state.go($state.current, {}, { reload: true });
                },
                reloadAll: function () {
                    location.reload();
                },
                redirectBack: function (redirectPageBack, time) {

                    if (!redirectPageBack) {
                        redirectPageBack = -1;
                    } else {
                        redirectPageBack = redirectPageBack * -1;
                    }

                    if (!time) {
                        time = 0;
                    }

                    setTimeout(function () {
                        window.history.go(redirectPageBack);
                    }, time);
                },
                hasHistory: function () {
                    if (window.history.length > 1) return true;
                    return false;
                }
            };
        }
    ]);

    app.factory('UrlBase', function () {
        return {
            get: function () {
                var url = location.href;
                var baseURL = url.substring(0, url.indexOf('/', 14));


                if (baseURL.indexOf('http://localhost') !== -1) {
                    // Base Url for localhost
                    var urlLocation = location.href; // window.location.href;
                    var pathname = location.pathname; // window.location.pathname;
                    var index1 = urlLocation.indexOf(pathname);
                    var index2 = urlLocation.indexOf("/", index1 + 1);
                    var baseLocalUrl = urlLocation.substr(0, index2);

                    return baseLocalUrl + "/";
                } else {
                    return baseURL + "/";
                }
            }
        };
    });
}(app));