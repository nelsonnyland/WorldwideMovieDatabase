var movieCount = 0;
var titleCount = [];

function addMovie() {
    titleCount.push(0);
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
    formGroup.appendChild(createJobTitleInputDiv());
    return formGroup;
}

function createJobTitleInputDiv() {
    var div = createInputDiv();
    div.setAttribute("id", "titles" + movieCount);
    addTitleToGivenParent(movieCount, div);
    return div;
}

function createMovieTitleFormGroup() {
    var formGroup = createFormGroupDiv();
    formGroup.appendChild(createLabel("Movie Title"));
    formGroup.appendChild(createMovieTitleInputDiv());
    return formGroup;
}

function createMovieTitleInputDiv() {
    var div = createInputDiv();
    div.appendChild(createInput("Movies[" + movieCount + "].Movie.Title"));
    return div;
}

function createInputDiv() {
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

function createInput(name) {
    var input = document.createElement("input");
    input.setAttribute("type", "text");
    input.setAttribute("name", name);
    input.setAttribute("class", "form-control text-body single-line");
    return input;
}

function createJobTitleInput(movieNum) {
    return createInput("Movies[" + movieNum + "].JobTitle");
}

function addTitle(movieNum) {
    var container = document.getElementById("titles" + movieNum);
    addTitleToGivenParent(movieNum, container);
}

function addTitleToGivenParent(movieNum, parent) {
    parent.appendChild(createJobTitleInput(movieNum));
    parent.appendChild(document.createElement("br"));
    titleCount[movieNum]++;

    console.log("titleCount: " + titleCount[movieNum]);
}

window.onload = function () {
    addMovie();
    document.getElementById("addMovie").onclick =
        addMovie;
    document.getElementById("addTitle").onclick = function() {
        addTitle(this.dataset.movieNum);
    };
};