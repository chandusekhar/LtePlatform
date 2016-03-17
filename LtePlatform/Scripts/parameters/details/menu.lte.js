﻿app.controller("menu.lte", function ($scope, $stateParams, networkElementService) {
    $scope.menuTitle = $stateParams.name + "详细信息";
    var rootUrl = "/Parameters/List#";
    $scope.menuItems = [
        {
            displayName: "基础数据总揽",
            url: rootUrl + "/"
        }, {
            displayName: "小区地图查询",
            url: rootUrl + "/query"
        }, {
            displayName: $stateParams.name + "基础信息",
            url: rootUrl + "/eNodebInfo" + "/" + $stateParams.eNodebId + "/" + $stateParams.name
        }
    ];
    networkElementService.queryCellSectorIds($stateParams.name).then(function (result) {
        for (var i = 0; i < result.length; i++) {
            $scope.menuItems.push({
                displayName: $stateParams.name + "-" + result[i] + "小区信息",
                url: rootUrl + "/cellInfo" + "/" + $stateParams.eNodebId + "/" + $stateParams.name + "/" + result[i]
            });
        }
    });
});