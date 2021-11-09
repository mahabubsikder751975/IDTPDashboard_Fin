
var chartHelper = (function () {

    'use strict';

    // Create the methods object
    var methods = {};

    //
    // Methods
    //

    methods.config = function (type, data) {
        let scales = {};
        if (type == 'stackbar') {
            type = 'bar';
            let stscales = {
                xAxes: [{ stacked: true }],
                yAxes: [{ stacked: true }]
            };
            Object.assign(scales, stscales);
        }
        if (type == 'bar') {
            let tscales = {                
                yAxes: [{
                    //scaleLabel: {
                    //    display: true,
                    //    labelString: 'Title'
                    //},
                    ticks: {
                        beginAtZero: true,
                        callback: function (label, index, labels) {
                            return label.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");;
                        }
                    }
                }]
            };
            Object.assign(scales, tscales);
        }

        //let tooltips = {
        //    callbacks: {
        //        label: function (t, d) {
        //            var xLabel = d.datasets[t.datasetIndex].label;
        //            var yLabel = t.yLabel.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        //            return xLabel + ': ' + yLabel;
        //        }
        //    }
        //};
        let tooltips = {
            callbacks: {
                title: function (tooltipItem, data) {
                    return data['labels'][tooltipItem[0]['index']];
                },
                label: function (tooltipItem, data) {
                    return data.datasets[tooltipItem.datasetIndex].label+': '+(data['datasets'][0]['data'][tooltipItem['index']]).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                },
            }
        };
        
        let plugins = {
            labels: false,
        };
        let options = {
            plugins,
            scales,
            legend: { display: true },
            title: {
                display: true,
                //text: 'Employee Count'
            },
            tooltips
        };
        const config = {
            type,
            data,
            options 
        }
        return config;
    };

    methods.data = function (xValues,...dataSets) {
        const data = {
            labels: xValues,
            datasets: dataSets
        };
        return data;
    };

    methods.on = function () {
        console.log('on');
    };
    methods.setChartTitle = function (key, value) {
        sessionStorage.setItem(key, value);
    };
    methods.getChartTitle = function (key) {
        return sessionStorage.getItem(key);
    };

    // Expose the public methods
    return methods;

})();