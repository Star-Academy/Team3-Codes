function checkForEnter(event) {
  if (event.key === "Enter") {
    const input = document.querySelector(".search-input");
    const value = input.value;

    const xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
      if (this.readyState === 4 && this.status === 200) {
        displayDocs(this.response);
      }
    };
    xhttp.open("POST", "https://localhost:5001/Search/GetMatchedResult");
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.responseType = "json";
    xhttp.send(JSON.stringify(value));
  }

  function test() {}

  function displayDocs(docs) {
    var template = "";
    let count = 1;
    template += `<a id="toggleButton" onclick="template+=<b>Document Name : "llll"</b>;" href="javascript:void(0);">lalala</a>`;
    for (const doc of docs) {
      template += `<div class="doc-card">
                <b>${count}</b>
                <br>
                <b>Document Name : ${doc.name}</b>
            </div>
            <div>
        <p id="textArea"><!-- This is where I want to additional text--></p>
        </div>
      <a id="toggleButton" onclick="toggleText(${doc.text});" href="javascript:void(0);">See More</a>`;
      count++;
    }

    document.getElementById("whole-body").innerHTML = template;
  }
  var status = "less";
  function toggleText(text) {
    if (status == "less") {
      document.getElementById("textArea").innerHTML = text;
      document.getElementById("toggleButton").innerText = "See Less";
      status = "more";
    } else if (status == "more") {
      document.getElementById("textArea").innerHTML = "";
      document.getElementById("toggleButton").innerText = "See More";
      status = "less";
    }
  }
}
