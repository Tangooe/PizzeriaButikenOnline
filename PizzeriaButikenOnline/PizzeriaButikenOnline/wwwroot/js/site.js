var HomeController = function () {

    var fail = function () {
        alert("Something failed");
    };

    var deleteDish = function (e) {
        var link = $(e.target);

        bootbox.dialog({
            message: "Är du säker på att du vill ta bort den här maträtten?",
            title: "Godkänn",
            buttons: {
                no: {
                    label: "Nej",
                    className: "btn-default",
                    callback: function () {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Ja",
                    className: "btn-danger",
                    callback: function () {
                        $.ajax({
                                url: "/api/dishes/" + link.attr("data-dish-id"),
                                method: "DELETE"
                            })
                            .done(function () {
                                link.parents("li").fadeOut(function () {
                                    $(this).remove();
                                });
                            })
                            .fail(fail);
                    }
                }
            }
        });
    };

    var deleteCategory = function (e) {
        var link = $(e.target);

        bootbox.dialog({
            message:
                '<p>Är du säker på att du vill ta bort den här kategorin?</p><p class="text-danger">OBS! ALLA maträtter under denna kategori kommer att försvinna!</p>',
            title: "Godkänn",
            buttons: {
                no: {
                    label: "Nej",
                    className: "btn-default",
                    callback: function () {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Ja",
                    className: "btn-danger",
                    callback: function () {
                        $.ajax({
                                url: "/api/categories/" + link.attr("data-category-id"),
                                method: "DELETE"
                            })
                            .done(function () {
                                link.parents(".js-category-group").fadeOut(function () {
                                    $(this).remove();
                                });
                            })
                            .fail(fail);
                    }
                }
            }
        });
    };

    var deleteIngredient = function(e) {
        var link = $(e.target);
        var linkId = link.attr("data-ingredient-id");

        bootbox.dialog({
            message: "Är du säker på att du vill ta bort den här ingrediensen?",
            title: "Godkänn",
            buttons: {
                no: {
                    label: "Nej",
                    className: "btn-default",
                    callback: function () {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "Ja",
                    className: "btn-danger",
                    callback: function () {
                        $.ajax({
                                url: "/api/ingredients/" + linkId,
                                method: "DELETE"
                            })
                            .done(function () {
                                $("ul.checkbox-grid > li.ingredient-" + linkId).each(function () {
                                    $(this).fadeOut(function () {
                                        $(this).remove();
                                    });
                                });
                            })
                            .fail(fail);
                    }
                }
            }
        });
    };

    var init = function() {
        $(".js-delete-dish").click(deleteDish);
        $(".js-delete-category").click(deleteCategory);
        $(".js-delete-ingredient").click(deleteIngredient);
    };

    $(function () {
        $('.js-toggle-empty-categories').change(function () {
            $('#js-empty-categories').toggle(this.checked);
        }).change();
    });

    return {
        init: init
    };
}();

var CartController = function()
{
    var deleteCartline = function() {
        $(".js-delete-cartline").click(function(e) {
            var link = $(e.target);
            var linkId = link.attr("data-cartline-id");

            $.ajax({
                    url: "/api/cart/removeline/" + linkId,
                    method: "DELETE"
                })
                .done(function() {
                    link.parents("tr").fadeOut(function() {
                        $(this).remove();
                    });
                })
                .fail(function() {
                    alert("Something failed");
                });
        });
    }
    var init= function() {
        $(".js-delete-cartline").click(deleteCartline);
    }

    return {
        init: init
    };
}();