$.fn.gallery = function (columns) {
    var $galleryContainer = $(this),
        $galleryListContainer = $galleryContainer.find('.gallery-list'),
        $imagesContainers = $galleryContainer.find('.image-container'),
        $selectedImagesContainer = $galleryContainer.find('.selected');

    // columns default values
    if (columns === undefined) {
        columns = 4;
    }

    // set-up columns
    $galleryContainer
        .addClass('gallery')
        .find('.image-container:nth-child(' + columns + 'n+1)').addClass('clearfix');

    // hide selected images container
    $selectedImagesContainer.hide();

    // click on gallery image
    $imagesContainers.click(function () {
        $galleryListContainer.addClass('disabled-background').addClass('blurred');

        // refresh selected images
        refreshSelectedImages($(this));

        $selectedImagesContainer.show();
    });

    // click on selected images large image
    $selectedImagesContainer.find('.current-image').click(function() {
        $selectedImagesContainer.hide();
        $galleryListContainer.removeClass('disabled-background').removeClass('blurred');
    });

    // click on selected images previous image
    $selectedImagesContainer.find('.previous-image').click(function() {
        var info = $(this).find('img').data('info');
        $galleryListContainer.find('img[data-info="' + info + '"]').parent().trigger('click');
    });

    // click on selected images next image
    $selectedImagesContainer.find('.next-image').click(function() {
        var info = $(this).find('img').data('info');
        $galleryListContainer.find('img[data-info="' + info + '"]').parent().trigger('click');
    });

    function refreshSelectedImages($selectedImageContainer) {
        var $selectedImage,
            $previousImageContainer,
            $previousImage,
            $nextImageContainer,
            $nextImage;

        // change current image
        $selectedImage = $selectedImageContainer.find('img');
        $selectedImagesContainer
            .find('.current-image img')
            .attr('src', $selectedImage.attr('src'))
            .data('info', $selectedImage.data('info'));

        //change previous image
        $previousImageContainer = $selectedImageContainer.prev();
        if ($previousImageContainer.length > 0) {
            $previousImage = $previousImageContainer.find('img');
        } else {
            $previousImage = $galleryListContainer.find('.image-container:last img');
        }
        $selectedImagesContainer
            .find('.previous-image img')
            .attr('src', $previousImage.attr('src'))
            .data('info', $previousImage.data('info'));

        //change next image
        $nextImageContainer = $selectedImageContainer.next();
        if ($nextImageContainer.length > 0) {
            $nextImage = $nextImageContainer.find('img');
        } else {
            $nextImage = $galleryListContainer.find('.image-container:first img');
        }
        $selectedImagesContainer
            .find('.next-image img')
            .attr('src', $nextImage.attr('src'))
            .data('info', $nextImage.data('info'));
    }
};