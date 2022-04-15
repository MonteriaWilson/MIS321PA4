const baseUrl = "https://localhost:5001/api/songs";
var songList = [];
var mySong = {};

function getSong() {
    var url = baseUrl;
    // let searchString = document.getElementById("getSong").value;

    // url += searchString;

    // console.log(searchString)

    fetch(url).then(function (response) {
        console.log(response);
        return response.json();
    }).then(function (json) {
        console.log(json)
        let html = ``;
        json.forEach((song) => {
            console.log(song.songTitle)
            html += `<div class="card col-md-4 bg-dark text-white">`;
            html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
            html += `<div class="card-img-overlay">`;
            html += `<h5 class="card-title">` + song.songTitle + `</h5>`;
            html += `</div>`;
            html += `</div>`;
        });

        if (html === ``) {
            html = "No Songs found :("
        }
        document.getElementById("cards2").innerHTML = html;

    }).catch(function (error) {
        console.log(error);
    });
}

// function getSong()
// {
//     const baseUrl = "https://localhost:5001/api/Songs";
//     fetch(baseUrl).then(function(response)
//     {
//         console.log(response);
//         return response.json();
//     }).then(function(json){
//         let html = " ";
//         json.forEach((song)={
//             html =+
//         }
//     })
// }

function postSong() {
    const baseUrl = "https://localhost:5001/api/songs";
    const addSong = document.getElementById("title").value;
    var song = {
        songTitle: addSong,
        songTimeStamp: new Date(),
        deleted: "",
        favorite: ""
    }
    console.log(song)
    fetch(baseUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-type": 'application/json'
        },
        body: JSON.stringify(song)
        //songTitle :addSong
    }).then((response) => {
        console.log(response);

    });


}
function bell() {
    const baseUrl = "https://localhost:5001/api/songs"
    const deleteSong = document.getElementById("deleteinput").value;
    fetch(`${baseUrl}/${deleteSong}`,{
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-type": 'application/json'
        }, 
    });
    
}
function putSong() {
    const baseUrl = "https://localhost:5001/api/songs"
    const favoriteSong = document.getElementById("favoriteSong").value;
    fetch(baseUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-type": 'application/json'
        }, body: JSON.stringify(favoriteSong)
    });


}
// function deleteSong() {
//     const baseUrl = "https://localhost:5001/api/songs"
//     const deleteSong = document.getElementById("deleteSong").value;
//     fetch(baseUrl, {
//         method: "DELETE",
//         headers: {
//             "Accept": 'application/json',
//             "Content-type": 'application/json'
//         }, body: JSON.stringify(deleteSong)
//     });
// }
