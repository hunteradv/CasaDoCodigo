class Cart {
    clickIncrement(btn) {
        let data = this.getData(btn);
        data.Quantity++;
        this.postQuantity(data);               
    }

    clickDecrement(btn) {
        let data = this.getData(btn);
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
        $.ajax({
            url: '/request/updatequantity',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        }).done(function (response) {
            let itemRequest = response.itemRequest;
            let lineOfItem = $('[item-id=' + itemRequest.id + ']');                       
            lineOfItem.find('input').val(itemRequest.quantity);
            lineOfItem.find('[subtotal]').html((itemRequest.subtotal).twoHouses());
        });
    }
}

var cart = new Cart();

Number.prototype.twoHouses = function() {
    return this.toFixed(2).replace('.', ',');
}