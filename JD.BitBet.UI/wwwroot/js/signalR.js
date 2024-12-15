function adjustBet(amount) {
    const betInput = document.getElementById('betAmount');
    let currentBet = parseInt(betInput.value) || 0;
    currentBet = Math.max(0, currentBet + amount); 
    betInput.value = currentBet;
}

//const connection = new signalR.HubConnectionBuilder()
//    .withUrl("/blackjackhub")
//    .build();

//connection.on("ReceiveMessage", function (user, message) {
//    const msg = `${user}: ${message}`;
//    const li = document.createElement("li");
//    li.textContent = msg;
//    const discussion = document.getElementById("discussion");
//    discussion.appendChild(li);
//    discussion.scrollTop = discussion.scrollHeight; // Auto-scroll to bottom
//});

//connection.on("PlayerJoined", function (connectionId) {
//    const msg = `Player ${connectionId} has joined the game.`;
//    addChatMessage(msg);
//});

//connection.on("PlayerLeft", function (connectionId) {
//    const msg = `Player ${connectionId} has left the game.`;
//    addChatMessage(msg);
//});

//connection.on("GameStateUpdated", function (gameState) {
//    if (gameState) {
//        updateGameState(gameState);
//    }
//});

//connection.start()
//    .then(function () {
//        const gameId = "@game?.Id"; 
//        if (gameId) {
//            connection.invoke("JoinGame", gameId)
//                .catch(err => console.error(err.toString()));
//        }
//    })
//    .catch(function (err) {
//        console.error(err.toString());
//        setTimeout(() => connection.start(), 5000); 
//    });

