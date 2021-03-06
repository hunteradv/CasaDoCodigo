class Cart {
    clickIncrement(button) {
        let data = this.getData(button);
        data.Quantity++;
        this.postQuantity(data);               
    }

    clickDecrement(button) {
        let data = this.getData(button);
        data.Quantity--;
        this.postQuantity(data);
    }

    updateQuantity(input) {
        let data = this.getData(input);
        this.postQuantity(data);
    }

    getData(element) {
        let itemLine = $(element).parents('[item-id]');
        let itemId = $(itemLine).attr('item-id');
        let newQuantity = $(itemLine).find('input').val();

        return {
            Id: itemId,
            Quantity: newQuantity
        };
    }

    postQuantity(data) {
        let token = $('[name=__RequestVerificationToken]').val();

        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/request/updatequantity',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            let itemRequest = response.itemRequest;
            let lineOfItem = $('[item-id=' + itemRequest.id + ']');                       
            lineOfItem.find('input').val(itemRequest.quantity);
            lineOfItem.find('[subtotal]').html((itemRequest.subtotal).twoHouses());

            let cartViewModel = response.cartViewModel;
            $('[numero-itens]').html('Total: ' + cartViewModel.items.length + ' itens');
            $('[total]').html((cartViewModel.total).twoHouses());

            if (itemRequest.quantity == 0) {
                lineOfItem.remove();
            }
        });
    }
}

var cart = new Cart();

Number.prototype.twoHouses = function() {
    return this.toFixed(2).replace('.', ',');
}