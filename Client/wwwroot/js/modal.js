var ModalFlow = state => {
    switch (state) {
        case "forgot":
            $('#exampleModalLongTitle').text("Forgot Password");
            $('#buttonModal').text("Send Email");
            $('#registerName').hide();
            $('#registerPassword').hide();
            $('#registerPhone').hide();
            $('#registerGender').hide();
            $('#registerPhone').hide();
            $('#registerDate').hide();
            break;
        case "register":
            $('#exampleModalLongTitle').text("Register");
            $('#buttonModal').text("Register");
            $('#registerName').show();
            $('#registerPassword').show();
            $('#registerPhone').show();
            $('#registerGender').show();
            $('#registerPhone').show();
            $('#registerDate').show();
            break;
      
        default:
        // code block
    }
}