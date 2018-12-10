var movieCount = 0;
var jobTitleCount = [];

function addMovie() {
    jobTitleCount.push(0);
    var container = document.getElementById("movies");    
    container.appendChild(createMovieTitleFormGroup());
    container.appendChild(createJobTitlesFormGroup());
    container.appendChild(createAddTitleFormGroup());
    container.appendChild(document.createElement("hr"));
    movieCount++;

    console.log("movieCount: " + movieCount);
}

function createAddTitleFormGroup() {
    var formGroup = createFormGroupDiv();
    var AddJobTitleBtn = createAddJobTitleBtn();
    formGroup.appendChild(createOffset2Div(AddJobTitleBtn));
    return formGroup;
}

function createAddJobTitleBtn() {
    var input = document.createElement("input");
    input.setAttribute("type", "button");
    input.setAttribute("id", "addTitle" + movieCount);
    input.setAttribute("value", "Add Job Title")
    input.setAttribute("class", "btn btn-sm");
    input.setAttribute("data-movie-num", "" + movieCount);

    input.onclick =  function() { addTitle(this.dataset.movieNum) };
    return input
}

function createOffset2Div(element) {
    var div = document.createElement("div");
    div.setAttribute("class", "col-md-10 offset-md-2");
    div.appendChild(element);
    return div;
}

function createJobTitlesFormGroup() {
    var formGroup = createFormGroupDiv();
    formGroup.appendChild(createLabel("Job Titles"));
    formGroup.appendChild(createJobTitleDropDownDiv());
    return formGroup;
}

function createJobTitleDropDownDiv() {
    var div = createDropDownDiv();
    div.setAttribute("id", "titles" + movieCount);
    addTitleToGivenParent(movieCount, div);
    return div;
}

function createMovieTitleFormGroup() {
    var formGroup = createFormGroupDiv();
    formGroup.appendChild(createLabel("Movie"));
    formGroup.appendChild(createMovieTitleDropDownDiv());
    return formGroup;
}

function createMovieTitleDropDownDiv() {
    var div = createDropDownDiv();
    div.appendChild(createDropDown("moviesDropDown", "MoviesToAdd[" + movieCount + "].MovieId"));
    return div;
}

function createDropDownDiv() {
    var div = document.createElement("div");
    div.setAttribute("class", "col-md-10");
    return div;
}


function createLabel(labelName) {
    var movieTitleLabel = document.createElement("label");
    movieTitleLabel.setAttribute("class", "control-label col-md-2");
    movieTitleLabel.innerText = labelName;
    return movieTitleLabel;
}

function createFormGroupDiv() {
    var formGroup = document.createElement("div");
    formGroup.setAttribute("class", "form-group");
    return formGroup;
}

function createDropDown(id, name) {
    var dropDown = document.getElementById(id).cloneNode(true);
    dropDown.removeAttribute("id");
    dropDown.removeAttribute("hidden");
    dropDown.setAttribute("name", name);
    return dropDown;
}

function createJobTitleDropDown(movieNum) {
    return createDropDown("jobTitlesDropDown", "MoviesToAdd[" + movieNum + "].Jobs[" + jobTitleCount[movieNum] + "].Id");
}

function addTitle(movieNum) {
    var container = document.getElementById("titles" + movieNum);
    addTitleToGivenParent(movieNum, container);
}

function addTitleToGivenParent(movieNum, parent) {
    parent.appendChild(createJobTitleDropDown(movieNum));
    parent.appendChild(document.createElement("br"));
    jobTitleCount[movieNum]++;

    console.log("titleCount: " + jobTitleCount[movieNum]);
}

window.onload = function () {
    addMovie();
    document.getElementById("addMovie").onclick = addMovie;
};