(function (app) {
    'use strict';

    app.factory('ApiService', ['$http', '$state', '$rootScope', 'UrlService', '$location', '$cookies',
        function ($http, $state, $rootScope, UrlService, $location, $cookies) {

            function getData(response, prop) {
                prop = !prop ? 'data' : prop;
                response = response.data;
                if (prop) {
                    if (response[prop] === 0 || response[prop] === false || response[prop]) {
                        return response[prop];
                    } else {
                        console.error("Propriedade de retorno não encontrada");
                        return {};
                    }
                } else {
                    return response;
                }
            }

            function getSuccess(response, reloadForm) {
                response = response.data;
                if (response.success) {
                    if (typeof reloadForm === "boolean" && reloadForm) {
                        $state.go($state.current.name, {}, { reload: true });
                    }
                    return {};
                } else {
                    getErrorMessage(response);
                }

                return reloadForm;
            }

            function getErrorMessage(response) {
                if (response && response.messages) {
                    var textarea = document.createElement("textarea");
                    for (var i = 0; response.messages.length > i; i++) {
                        textarea.value += "- " + response.messages[i] + "<br/>";
                    }
                    var message = textarea.value;
                    

                }
            }

            function request(rootScope, http, service, controller, action, data, method, callback, token, responseType) {

                var load = typeof token === "boolean" ? token : true;

                if (typeof callback === "boolean") {
                    load = callback;
                }

                if (data && !callback) {
                    callback = data;
                }

                var url = null;

                if (action) {
                    if (typeof action === "function") {
                        token = callback;
                        callback = action;
                        url = service.getAPI(controller);
                    } else {
                        if (method === "get" && typeof data === 'string' || data instanceof String || typeof data === 'number') {
                            url = service.getAPIAction(controller, action, data);
                        } else {
                            url = service.getAPIAction(controller, action);
                        }
                    }
                } else {
                    url = service.getAPI(controller);
                }

                if (load) {
                    $rootScope.isLoading = true;
                }

                token = !token || load ? rootScope.currentLogin ? rootScope.currentLogin.token : token : token;

                var headers = token ? { 'Authorization': 'Bearer ' + token } : {};

                $http({
                    method: method,
                    url: url,
                    data: data,
                    headers: headers,
                    responseType: responseType || 'json'
                })
                    .then(function successCallback(response) {
                        callback(response);
                        $rootScope.isLoading = false;
                    }, function errorCallback(response) {
                        console.error(response.data);
                        callback(response);
                        $rootScope.isLoading = false;
                    });

            }

            function VerifyStatus(response) {
                if (response.status === 401) {
                    if ($location.$$path.indexOf('app') > -1) {
                        $rootScope.currentLogin = null;
                        $cookies.remove($rootScope.cookieName);
                        return false;
                    }

                    return false;
                } else if (response.status === 500) {
                   
                    return false;
                }

                return true;
            }


            function download(data, filename, type) {
                var a = document.createElement("a"),
                    file = new Blob([data], { type: type });
                if (window.navigator.msSaveOrOpenBlob) // IE10+
                    window.navigator.msSaveOrOpenBlob(file, filename);
                else { // Others
                    var url = URL.createObjectURL(file);
                    a.href = url;
                    a.download = filename;
                    document.body.appendChild(a);
                    a.click();
                    setTimeout(function () {
                        document.body.removeChild(a);
                        window.URL.revokeObjectURL(url);
                    }, 0);
                }
            }

            return {
                get: function (controller, action, data, callback, load) {
                    return request($rootScope, $http, UrlService, controller, action, data, "get", callback, load);
                },
                getToken: function (controller, action, data, token, callback) {
                    if (typeof data === "string") {
                        data = { value: data };
                    }
                    return request($rootScope, $http, UrlService, controller, action, data, "get", callback, token);
                },
                getArrayBuffer: function (controller, action, data, callback, load) {
                    return request($rootScope, $http, UrlService, controller, action, data, "post", callback, load, 'arraybuffer');
                },
                post: function (controller, action, data, callback, token) {
                    return request($rootScope, $http, UrlService, controller, action, data, "post", callback, token);
                },
                postToken: function (controller, action, data, token, callback) {
                    return request($rootScope, $http, UrlService, controller, action, data, "post", callback, token);
                },
                put: function (controller, action, data, callback) {
                    return request($rootScope, $http, UrlService, controller, action, data, "put", callback);
                },
                download: download,
                getResponseData: function (response, prop) {
                    if (VerifyStatus(response)) {
                        if (response.data.success) {
                            return getData(response, prop);
                        } else {
                            if (!prop) {
                                return response.data;
                            } else {
                                getErrorMessage(response.data);
                                return {};
                            }
                        }
                    }
                },
                getResponse: function (response, reload) {
                    if (VerifyStatus(response)) {
                        if (response.data.success) {
                            getSuccess(response, reload);
                            return true;
                        } else {
                            getErrorMessage(response.data);
                            return false;
                        }
                    }
                }
            };
        }
    ]);
}(app));