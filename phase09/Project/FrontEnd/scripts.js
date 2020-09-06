function checkForEnter(event) {
    if (event.key === 'Enter') {
        const input = document.querySelector('.search-input');
        const value = input.value;
        const request = {
            city: value
        };

        const xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                console.log(this.response);
            }
        };
        xhttp.open('POST', 'https://localhost:5001/Search/GetMatchedResult');
        xhttp.setRequestHeader('Content-type', 'application/json');
        xhttp.responseType = 'json';
        xhttp.send(JSON.stringify(request));
    }
}