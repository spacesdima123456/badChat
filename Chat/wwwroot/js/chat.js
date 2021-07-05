const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

hubConnection.on("RefreshUsersOnline", function (usersConnections) {
    let html = '';
    const lgiUsers = $('#LgiUsers');
    usersConnections.forEach(function(user) {
        html += `<li class="list-group-item">${user.fullName}</li>`;
    });

    lgiUsers.html(html);
});

hubConnection.start();