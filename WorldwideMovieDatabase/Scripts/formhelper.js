window.onload = function () {
    document.getElementById("addMovie").onclick = addItem;
    document.getElementById("addTitle").onclick = addItem;
};

var allItems = [];
function saveItem() {
    var itemTitle = document.getElementById("title").value;
    var newTask = new ToDoItem(itemTitle);
    allItems.push(newTask);
    addToDoItem(itemTitle);
    clearTextboxes();
}
function addToDoItem(itemTitle) {
    var listItems = document.getElementById("listItems");
    var newItem = document.createElement("li");
    var textNode = document.createTextNode(itemTitle);
    newItem.appendChild(textNode);
    listItems.appendChild(newItem);
    newItem.onclick = function () {
        if (this.getAttribute("class") == null) {
            this.setAttribute("class", "itemDone");
        }
        else {
            this.removeAttribute("class");
        }
    };
}
function displayItems() {
    for (var i = 0; i < allItems.length; i++) {
        var currItem = allItems[i];
        alert(currItem.title);
    }
}
var ToDoItem = (function () {
    function ToDoItem(title) {
        this.title = title;
    }
    return ToDoItem;
}());

https://stackoverflow.com/questions/26227487/adding-textbox-on-button-click-with-javascript
https://stackoverflow.com/questions/23125087/adding-textbox-dynamically-and-save-values-to-the-database-in-asp-net-mvc