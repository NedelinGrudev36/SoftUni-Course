//TODO...
let baseUrl = 'http://localhost:3030/jsonstore/games/';

let addButtonElement = document.getElementById('add-game');
let editButtonElement = document.getElementById('edit-game');
let loadButtonElement = document.getElementById('load-games');
let gameNameInputElement = document.getElementById('g-name');
let typeInputElement = document.getElementById('type');
let maxPlayersInputElement = document.getElementById('players');
let gamesListElement = document.getElementById('games-list');
let formElement = document.getElementById('form');

loadButtonElement.addEventListener('click', loadGames);

async function loadGames(){
    let response = await fetch(baseUrl);
    let data = await response.json();

    gamesListElement.innerHTML = '';

    for (const game of Object.values(data)) {
        let boardDiv = document.createElement('div');
        boardDiv.className = 'board-game';
        gamesListElement.appendChild(boardDiv);

        let contentDiv = document.createElement('div');
        contentDiv.className = 'content';
        boardDiv.appendChild(contentDiv);

        let pName = document.createElement('p');
        pName.textContent = game.name;
        contentDiv.appendChild(pName);

        let pPlayers = document.createElement('p');
        pPlayers.textContent = game.players;
        contentDiv.appendChild(pPlayers);

        let pType = document.createElement('p');
        pType.textContent = game.type;
        contentDiv.appendChild(pType);

        let buttonsContainer = document.createElement('div');
        buttonsContainer.className = 'buttons-container';
        boardDiv.appendChild(buttonsContainer);

        let changeButton = document.createElement('button');
        changeButton.className = 'change-btn';
        changeButton.textContent = 'Change';
        buttonsContainer.appendChild(changeButton);

        let deleteButton = document.createElement('button');
        deleteButton.className = 'delete-btn';
        deleteButton.textContent = 'Delete';
        buttonsContainer.appendChild(deleteButton);

        changeButton.addEventListener('click', () => {
            formElement.setAttribute('data-id', game._id);

            gameNameInputElement.value = game.name;
            typeInputElement.value = game.type;
            maxPlayersInputElement.value = game.players;

            editButtonElement.disabled = false;
            addButtonElement.disabled = true;

            boardDiv.remove();
        });

        deleteButton.addEventListener('click', async () => {
            await fetch (`${baseUrl}${game._id}`, {
                method: 'DELETE',
            });

            boardDiv.remove();
        });
    }
}

addButtonElement.addEventListener('click', addGame);

async function addGame(){
    let {name, players, type} = getInputData();

    let response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            name,
            players,
            type,
        })
    });

    if(!response.ok){
        return;
    }

    await loadGames();
    clearInputs();
}

editButtonElement.addEventListener('click', editGame);

async function editGame(){
    const {name, type, players} = getInputData();

    const gameId = formElement.getAttribute('data-id');

    let response = await fetch(`${baseUrl}${gameId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: gameId,
            name,
            type,
            players,
        })
    });

    if(!response.ok){
        return;
    }

    editButtonElement.disabled = true;
    addButtonElement.disabled = false;

    formElement.removeAttribute('data-id');

    clearInputs();

    loadGames();
}

function clearInputs(){
    gameNameInputElement.value = '';
    typeInputElement.value = '';
    gamesListElement.value = '';
}

function getInputData(){
    const name = gameNameInputElement.value;
    const type = typeInputElement.value;
    const players = maxPlayersInputElement.value;

    return {name, players, type};
}