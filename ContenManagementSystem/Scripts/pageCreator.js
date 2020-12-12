function onChangeNumberOfSections() {
    let numberOfSections = document.getElementById('numberOfSections');
    let sectionNumber = document.getElementById('sectionNumber');
    while(sectionNumber.hasChildNodes()){
        sectionNumber.removeChild(sectionNumber.lastChild);
    }
    for (let index = 0; index < numberOfSections.value; index++) {
        let option = document.createElement("option");
        option.value = index;
        option.text = index;
        sectionNumber.appendChild(option);
    }
}

function onChangeSectionNumber() {
    
}

function onChangeNumberOfDivisions() {
    let numberOfDivisions = document.getElementById('numberOfDivisions');
    let divisionNumber = document.getElementById('divisionNumber');
    while(divisionNumber.hasChildNodes()){
        divisionNumber.removeChild(divisionNumber.lastChild);
    }
    for (let index = 0; index < numberOfDivisions.value; index++) {
        let option = document.createElement("option");
        option.value = index;
        option.text = index;
        divisionNumber.appendChild(option);
    }
}


function save() {
    let data = { 
        pageName: document.getElementById('pageName').value,
        numberOfSections:document.getElementById('numberOfSections').value,
        sectionNumber:document.getElementById('sectionNumber').value,
        numberOfDivisions:document.getElementById('numberOfDivisions').value,
        divisionNumber:document.getElementById('divisionNumber').value,
        divisionType: document.getElementById('divisionType').value
    };
    
    fetch(window.location.protocol + "//" + window.location.host + "/Page/temp", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    })
    .then(data => {
        let a = document.createElement("a");
        a.setAttribute("href", window.location.protocol + "//" + window.location.host + "/Page/Index/test")
        a.click();
    })
    .catch((error) => {
      console.error('Error:', error);
    });
}

