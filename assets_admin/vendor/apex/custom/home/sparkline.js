// Sparkline 1
var options1 = {
	series: [
		{
			name: "Purchases",
			data: [1, 2, 3, 4, 5, 4, 3],
		},
		{
			name: "Purchases",
			data: [2, 3, 4, 5, 6, 5, 4],
		},
	],
	chart: {
		type: "bar",
		height: 50,
		width: 90,
		stacked: true,
		width: "100%",
		sparkline: {
			enabled: true,
		},
	},
	colors: ["#cccccc", "#0068ff"],
	stroke: {
		width: 0,
	},
	tooltip: {
		fixed: {
			enabled: false,
		},
		x: {
			show: false,
		},
		marker: {
			show: false,
		},
	},
	xaxis: {
		type: "day",
		categories: [
			"Monday",
			"Tuesday",
			"Wednesday",
			"Thursday",
			"Friday",
			"Saturday",
			"Sunday",
		],
	},
	tooltip: {
		y: {
			formatter: function (val) {
				return val + "K";
			},
		},
	},
};
var chart1 = new ApexCharts(document.querySelector("#option1"), options1);
chart1.render();

// Sparkline 2
var options2 = {
	series: [
		{
			name: "Purchases",
			data: [1, 2, 3, 4, 5, 6, 4],
		},
		{
			name: "Purchases",
			data: [2, 3, 4, 5, 6, 6, 3],
		},
	],
	chart: {
		type: "bar",
		height: 50,
		width: 90,
		stacked: true,
		width: "100%",
		sparkline: {
			enabled: true,
		},
	},
	colors: ["#cccccc", "#0068ff"],
	stroke: {
		width: 0,
	},
	tooltip: {
		fixed: {
			enabled: false,
		},
		x: {
			show: false,
		},
		marker: {
			show: false,
		},
	},
	xaxis: {
		type: "day",
		categories: [
			"Monday",
			"Tuesday",
			"Wednesday",
			"Thursday",
			"Friday",
			"Saturday",
			"Sunday",
		],
	},
	tooltip: {
		y: {
			formatter: function (val) {
				return val + "K";
			},
		},
	},
};
var chart2 = new ApexCharts(document.querySelector("#option2"), options2);
chart2.render();

// Sparkline 3
var options3 = {
	series: [
		{
			name: "Purchases",
			data: [1, 2, 3, 4, 5, 6, 5],
		},
		{
			name: "Purchases",
			data: [2, 3, 4, 5, 6, 7, 4],
		},
	],
	chart: {
		type: "bar",
		height: 50,
		width: 90,
		stacked: true,
		width: "100%",
		sparkline: {
			enabled: true,
		},
	},
	colors: ["#cccccc", "#0068ff"],
	stroke: {
		width: 0,
	},
	tooltip: {
		fixed: {
			enabled: false,
		},
		x: {
			show: false,
		},
		marker: {
			show: false,
		},
	},
	xaxis: {
		type: "day",
		categories: [
			"Monday",
			"Tuesday",
			"Wednesday",
			"Thursday",
			"Friday",
			"Saturday",
			"Sunday",
		],
	},
	tooltip: {
		y: {
			formatter: function (val) {
				return val + "K";
			},
		},
	},
};
var chart3 = new ApexCharts(document.querySelector("#option3"), options3);
chart3.render();