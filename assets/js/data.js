google.charts.load('current', {'packages':['corechart', 'line']});
google.charts.setOnLoadCallback(drawChart);
				
function drawChart() {
	var data = new google.visualization.DataTable();
					
	data.addColumn('date', 'Year');
	data.addColumn('number', 'Sexual Offences');
	data.addColumn({'type': 'string', 'role': 'tooltip', 'p':{'html': true}});
					
	data.addRows([
		[new Date('2003'), 308, createCustomHTMLContent('2003', '308')],
		[new Date('2004'), 388, createCustomHTMLContent('2004', '388')],
		[new Date('2005'), 418, createCustomHTMLContent('2005', '418')],
		[new Date('2006'), 373, createCustomHTMLContent('2006', '373')],
		[new Date('2007'), 307, createCustomHTMLContent('2007', '307')],
		[new Date('2008'), 280, createCustomHTMLContent('2008', '280')],
		[new Date('2009'), 323, createCustomHTMLContent('2009', '323')],
		[new Date('2010'), 403, createCustomHTMLContent('2010', '403')],
		[new Date('2011'), 437, createCustomHTMLContent('2011', '437')],
		[new Date('2012'), 413, createCustomHTMLContent('2012', '413')],
		[new Date('2013'), 427, createCustomHTMLContent('2013', '427')],
		[new Date('2014'), 469, createCustomHTMLContent('2014', '469')],
		[new Date('2015'), 517, createCustomHTMLContent('2015', '517')]
	]);
					
	var options = {
		chartArea: {
			left:'10%', 
			top:'1%', 
			bottom: '10%', 
			backgroundColor: 'snow'
		},
		backgroundColor: {fill: 'none', stroke: 'none'},			
		height: '100%',
		width: '100%',
		legend: {position: 'none'},
		colors: ['#dd5c94'],
		hAxis: {
			title: 'Year', 
			titleTextStyle: {fontName: 'Segoe UI', color: '#565656', italic: false}, 
			showTextEvery: 1, 
			textStyle: {fontSize: 9, fontName: 'Segoe UI'}, 
			minorGridlines: {count: 0},
			gridlines: {minSpacing: 1, multiple: 1, color: 'gray', count: 12, interval: [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]}
		},
		vAxis: {
			viewWindow: {max: 540, min: 260}, 
			textStyle: {fontSize: 9, fontName: 'Segoe UI'}, 
			minValue: 275, 
			title: 'Sexual Offences', 
			titleTextStyle: {fontName: 'Segoe UI', color: '#565656', italic: false}, 
			gridlines: {color: 'papayaWhip', multiple: 50},
			minorGridlines: {color: 'papayaWhip'}
		},
		tooltip: {isHtml: true}
	};
		
	var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));
	chart.draw(data, options);
}
				
function createCustomHTMLContent(year, sexOffences) {
	return '<div style="padding:5px 5px 5px 5px; font-family:Segoe UI";>' +
		'<div><b>Year: </b>' + year + '</div>' + 
		'<div><b> Sexual Offences: </b>' + sexOffences + '</div>' +
		'</div>';
}