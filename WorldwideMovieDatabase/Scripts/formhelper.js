var movieCount = 0;
var titleCount = 0;

function addMovie() {
    var container = document.getElementById("movie");    
    var input = document.createElement("input");
    input.setAttribute("type", "text");
    input.setAttribute("name", "Movies[" + movieCount + "].Title");
    input.setAttribute("class", "form-control");
    container.appendChild(input);
    movieCount++;

    console.log("movieCount: " + movieCount);
}

function addTitle() {
    var container = document.getElementById("title");
    var input = document.createElement("input");
    input.setAttribute("type", "text");
    input.setAttribute("name", "titleInput" + titleCount);
    input.setAttribute("class", "form-control");
    container.appendChild(input);
    titleCount++;

    console.log("titleCount: " + titleCount);
}

window.onload = function () {
    document.getElementById("addMovie").onclick =
        addMovie;
    document.getElementById("addTitle").onclick =
        addTitle;
};