app.controller('pontosCtrl', ['$scope', 'ApiService',
    function ($scope, ApiService) {
        'use strict';

        $scope.send = function () {
            if ($scope.model != null && $scope.model.pontos != null) {
                ApiService.post('Pontos', 'input', $scope.model, function () {
                    window.alert("Gravado com sucesso!");
                    $scope.model = null;
                });
            }
            else {
                window.alert("Favor preencher os pontos!");
            }
          
        };
    }
]);
