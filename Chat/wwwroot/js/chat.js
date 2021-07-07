(function() {
    const hubConnection = new window.signalR.
        HubConnectionBuilder().
        withUrl("/chat").build();

    function UsersViewModel() {
        const self = this;

        self.users = ko.observableArray([]);

        self.chosenUser = ko.observable({ fullName: '', userId: '' });

        self.txtMessage = ko.observable('');
        self.text = ko.observable('');

        self.isVisibleChat = ko.observable(false);

        self.sendMessage = function () {
            pasteHtmlMessageChat(self.txtMessage());
            hubConnection.invoke("SendMessage", self.chosenUser().userId, self.txtMessage());
            self.txtMessage('');
        }

        self.userSelected = function(person) {
            self.chosenUser(person);
            self.isVisibleChat(true);
        }
    }

    const usersViewModel = new UsersViewModel();

    const pasteHtmlMessageChat = (message) => {
        const elem = usersViewModel.text() + `<p style="font-size:20px;">${message}</p>`;
        usersViewModel.text(elem);
    }

    hubConnection.on("RefreshUsersOnline", function (users) {
            usersViewModel.users(users);
    });

    hubConnection.on("GetMessage", function (message) {
        pasteHtmlMessageChat(message);
    });

    ko.applyBindings(usersViewModel);
    hubConnection.start();

})();


