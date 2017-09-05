﻿var HomeController = function() {

    var init = function() {
        $(".js-delete-dish").click(function (e) {
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
                                .fail(function () {
                                    alert("Something failed!");
                                });
                        }
                    }
                }
            });
        });

        $(".js-delete-category").click(function (e) {
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
                                .fail(function () {
                                    alert("Something failed!");
                                });
                        }
                    }
                }
            });
        });

        $(".js-delete-ingredient").click(function (e) {
            var link = $(e.target);

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
                                    url: "/api/ingredients/" + link.attr("data-ingredient-id"),
                                    method: "DELETE"
                                })
                                .done(function () {
                                    $("ul.checkbox-grid > li").each(function () {
                                        //TODO: find out how to remove the selected item only and not all of them
                                        $(this).fadeOut(function () {
                                            $(this).remove();
                                        });
                                    });
                                })
                                .fail(function () {
                                    alert("Something failed!");
                                });
                        }
                    }
                }
            });
        });

        $(function () {
            $('.js-toggle-empty-categories').change(function () {
                $('#js-empty-categories').toggle(this.checked);
            }).change();
        });
    };

    return {
        init: init
    }
}();