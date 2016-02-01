﻿app.directive('workitemCdma', function () {
    return {
        restrict: 'EA',
        replace: true,
        template: '<table class="table table-hover">\
                    <tbody>\
                        <tr>\
                            <td>小区编号</td>\
                            <td>{{cdmaCellDetails.cellId}}</td>\
                            <td>经度</td>\
                            <td>{{cdmaCellDetails.longtitute}}</td>\
                            <td>纬度</td>\
                            <td>{{cdmaCellDetails.lattitute}}</td>\
                        </tr>\
                        <tr>\
                            <td>挂高</td>\
                            <td>{{cdmaCellDetails.height}}</td>\
                            <td>方位角</td>\
                            <td>{{cdmaCellDetails.azimuth}}</td>\
                            <td>下倾角</td>\
                            <td>{{cdmaCellDetails.downTilt}}</td>\
                        </tr>\
                        <tr>\
                            <td>室内外</td>\
                            <td>{{cdmaCellDetails.indoor}}</td>\
                            <td>天线增益</td>\
                            <td>{{cdmaCellDetails.antennaGain}}</td>\
                            <td>PN</td>\
                            <td>{{cdmaCellDetails.pn}}</td>\
                        </tr>\
                        <tr>\
                            <td>1X频点</td>\
                            <td>{{cdmaCellDetails.onexFrequencyList}}</td>\
                            <td>DO频点</td>\
                            <td>{{cdmaCellDetails.evdoFrequencyList}}</td>\
                            <td>LAC</td>\
                            <td>{{cdmaCellDetails.lac}}</td>\
                        </tr>\
                    </tbody>\
        </table>'
    };
});