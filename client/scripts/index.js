
function findSongs(){
    var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    let searchString = document.getElementById("searchSong").value;

    url += searchString;

    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
		json.forEach((song) => {
            console.log(song.title)
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">`+song.title+`</h5>`;
            html += `</div>`;
            html += `</div>`;
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
    })
}

  const baseUrl = "https://localhost:5001/api/Songs"; 
  var songList = [];
  var mySong = {};

    function getSong()
    {
        const baseUrl = "https://localhost:5001/api/Songs";
        fetch(baseUrl).then(function(response)
        {
            console.log(response);
            return response.json();
        }).then(function(json){
            let html = " ";
            json.forEach((song)={
                html =+
            }
        }
    }
    
    function postSong()
    {
        const baseUrl = "https://localhost:5001/api/Songs"; 
        const addSong = document.getElementById("add").value;
        fetch(baseUrl,{
        method : "Post",
        headers: {
            "Accept" : 'application/json',
            "Context-type": 'application/json'
        },
        body: JSON.stringify({
            addSong :add
        })
    }).then((response)=>{
        console.log(response);
        getSong();
    }

    }
    function putSong(id)
    {
        
    }
    function deleteSong(id)
    {

    }
     