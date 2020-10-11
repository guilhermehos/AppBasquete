app.controller('resultadoCtrl', ['$scope', 'ApiService',
    function ($scope, ApiService) {
        'use strict';

        $scope.get = function () {
            ApiService.get('Pontos', 'get', function (response) {
                $scope.model = ApiService.getResponseData(response);
            });
        };

        $scope.get();
    }
]);