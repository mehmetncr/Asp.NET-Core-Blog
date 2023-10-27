function addComment() {


    // Formdaki bilgileri al
    var name = document.getElementById('name').value;
    var mail = document.getElementById('email').value;
    var content = document.getElementById('message').value;
    var BlogId = document.getElementById('blogId').value;
    //tekrar validasyona girerse önceki spanlar temizlenir
    $('#commentUserNameValid').text('');    
    $('#commentMailValid').text('');    
    $('#commentContentValid').text('');       

    if (name.trim() === '') {
        $('#commentUserNameValid').text('Ad alanı boş bırakılamaz.');        
    }   
    if (mail.trim() === '') {
        $('#commentMailValid').text('Mail alanı boş bırakılamaz.');       
    } else {
        var mailFormat = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;  //mail adresi validasyonu
        if (!mail.match(mailFormat)) {
            $('#commentMailValid').text('Lütfen geçerli bir e-posta adresi girin.');           
        }
    }
        // Yorum en az 35 karakter olmalıdır
    if (content.length < 35) {
        $('#commentContentValid').text('Yorum en az 35 karakter içermelidir.');       
    }
    else
    {
        var Comment = {   //yeni bir yorum nesnesi oluşur
            CommentUserName: name,
            CommentMail: mail,
            CommentContent: content,
            BlogID: BlogId

        };
        $.ajax({
            url: '/Comment/Addcomment',  //yorum ekleyecek metoda yorumu data ile gönder
            type: 'POST',
            data: Comment,

            success: function (result) {    //yorum ekleme başarılı olursa inputları temizle ve yorum alındı  yaz       
                $('#name').val('');
                $('#email').val('');
                $('#message').val('');
                $('#infodiv').css('display', 'block');
                $('#info').text('Yorumunuz alınıştır onay bekliyor.');



            },
            error: function (xhr, status, error) {

                console.error(error);


            }
        });
    }

};
function addReplayComment() {


    // Formdaki bilgileri al
    var name = document.getElementById('replayname').value;
    var mail = document.getElementById('replayemail').value;
    var content = document.getElementById('replaymessage').value;
    var PrntCommentID = document.getElementById('replayPrntComment').value;
    var BlogRplyCommentID = document.getElementById('replayBlog').value;
    //tekrar validasyona girerse önceki spanlar temizlenir
    $('#replayUserNameValid').text('');
    $('#replayMailValid').text('');
    $('#replayContentValid').text('');

    if (name.trim() === '') {
        $('#replayUserNameValid').text('Ad alanı boş bırakılamaz.');
    }
    if (mail.trim() === '') {
        $('#replayMailValid').text('Mail alanı boş bırakılamaz.');
    } else {
        var mailFormat = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;  //mail adresi validasyonu
        if (!mail.match(mailFormat)) {
            $('#replayMailValid').text('Lütfen geçerli bir e-posta adresi girin.');
        }
    }
    // Yorum en az 35 karakter olmalıdır
    if (content.length < 35) {
        $('#replayContentValid').text('Yorum en az 35 karakter içermelidir.');
    }
    else {
        var ReplyCommentViewModel = {   //yeni bir yorum nesnesi oluşur
            CommentUserName: name,
            CommentMail: mail,
            CommentContent: content,
            ParentCommentID: PrntCommentID,
            BlogReplayCommentID: BlogRplyCommentID

        };
        $.ajax({
            url: '/Comment/AddReplayComment',  //yorum ekleyecek metoda yorumu data ile gönder
            type: 'POST',
            data: ReplyCommentViewModel,

            success: function (result) {    //yorum ekleme başarılı olursa inputları temizle ve yorum alındı  yaz       
                $('#replayname').val('');
                $('#replayemail').val('');
                $('#replaymessage').val('');
                $('#replayinfodiv').css('display', 'block');
                $('#replayinfo').text('Yorumunuz alınıştır onay bekliyor.');



            },
            error: function (xhr, status, error) {

                console.error(error);


            }
        });
    }

};