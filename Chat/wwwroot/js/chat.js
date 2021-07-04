const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

hubConnection.on("RefreshUsersOnline", function (usersConnections) {
    let html = '';
    const lgiUsers = $('#LgiUsers');

    for (const [key, value] of Object.entries(usersConnections)) {
        html += `<li class="list-group-item">${value.userName}</li>`;
    }

    lgiUsers.html(html);
});

hubConnection.start();