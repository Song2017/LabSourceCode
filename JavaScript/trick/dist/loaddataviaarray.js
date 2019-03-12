var jsonData =
    JSON.parse('[{"col1":11,"col2":12,"col3":13},' +
        '{"col1":21,"col2":22,"col3":23},' +
        '{"col1":31,"col2":32,"col3":33}, ' +
        '{"col1":41,"col2":42,"col3":43}]');
var eles = document.getElementsByClassName("divTableCell");

function loadTableData() {
    console.log('loadTableData')
    // below code block effect result is equal
    eles[0].innerHTML = jsonData[0].col1;
    eles[1].innerHTML = jsonData[0].col2;
    eles[2].innerHTML = jsonData[0].col3;
    eles[3].innerHTML = jsonData[1].col1;
    eles[4].innerHTML = jsonData[1].col2;
    eles[5].innerHTML = jsonData[1].col3;
    eles[6].innerHTML = jsonData[2].col1;
    eles[7].innerHTML = jsonData[2].col2;
    eles[8].innerHTML = jsonData[2].col3;
    eles[9].innerHTML = jsonData[3].col1;
    eles[10].innerHTML = jsonData[3].col2;
    eles[11].innerHTML = jsonData[3].col3;
}

function loadTableDataViaAry() {
    console.log('loadTableDataViaAry')
    var staticColumns = ['col1', 'col2', 'col3']
    for (var i = 0; i < 12; i++)
        eles[i].innerHTML = jsonData[Math.floor(i / 3)][staticColumns[i % 3]];
}