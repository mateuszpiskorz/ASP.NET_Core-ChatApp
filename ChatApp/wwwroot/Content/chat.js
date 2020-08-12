let currentContact = null;
let newMessageTpl =
    `<div>
                <div id="msg-{{id}}" class="row __chat__par__">
                    <div class="__chat__">
                        <p>{{body}}</p>
                        <p class="delivery-status">Delivered</p>
                    </div>
                </div>
            </div>`;
//Selecting contact to chat 
$('.user_item').click(function (e) {
    e.preventDefault();

    currentContact = {
        id: $this.data('contact-id'),
        name: $this.data('contact-name'),
    };

    $('#contacts').find('li').removeClass('active');
    $('#contacts .contact-' + currentContact.id).find('li').addClass('active');
    getchat(currentContact.id);


});

//Get chat data
function getChat(contact_id) {
    $.get("contact/conversations" + contact_id)
        .done(function (resp) {
            var chat_data = resp.data || [];
            loadChat(chat_data);
        });
}

function loadChat(chat_data) {
    chat_data.forEach(function (data) {
        displayMessage(data);
    });

    $('.chat_body').show();
    $('.__no__chat__').hide();
}

function displayMessage(message_obj) {
    const msg_id = message_obj.Id;
    const msg_body = message_obj.Message;

    let template = $(newMessageTpl).html();

    template = template.replace("{{id}}", msg_id);
    template = template.replace("{{body}}", msg_body);

    template = $(template);

    if (message_obj.SenderId == @ViewBag.currentUser.id) {
        template.find('__chat__').addClass('from__chat');
    }
            else
    {
        template.find('__chat__').addClass('receive__chat');
    }

    if (message_obj.status == 1) {
        template.find('.delivery-status').show();
    }

    $('.chat__main').append(template);
}

