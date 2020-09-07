function checkForEnter(event, selectorName) {
    if (event.key === 'Enter') {
        const input = document.querySelector(selectorName);
        const value = input.value;

        const xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                displayDocs(this.response);
            }
        };
        xhttp.open('POST', 'https://localhost:5001/Search/GetMatchedResult');
        xhttp.setRequestHeader('Content-type', 'application/json');
        xhttp.responseType = 'json';
        xhttp.send(JSON.stringify(value));
    }
}

function displayDocs(docs) {
    let template = '';
    template+=makeSearchBar();

    let counter = 1;
    for (const doc of docs) {
        template +=
            `<button type="button" class="collapsible"> <h3>${counter} &nbsp;&#8594; &nbsp;${doc.name} </h3></button>
        <div class="content">
         <p>
            ${doc.text}
        </p>
        </div>
       `;
        counter++;
    }

    document.getElementById('whole-body').innerHTML = template;
    var coll = document.getElementsByClassName("collapsible");
    var i;

    for (i = 0; i < coll.length; i++) {
        coll[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var content = this.nextElementSibling;
            if (content.style.display === "block") {
                content.style.display = "none";
            } else {
                content.style.display = "block";
            }
        });
    }
}
function makeSearchBar() {
    return `<div class="search-bar">
    <input class="search-bar" type="text" name="search" placeholder="Search another string" onkeyup="checkForEnter(event,'.search-bar')" />
    </div>`;
}


