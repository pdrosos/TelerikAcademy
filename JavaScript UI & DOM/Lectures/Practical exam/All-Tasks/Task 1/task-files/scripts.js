function createImagesPreviewer(selector, items) {
    var container,
        itemsCount = items.length,
        thumbnailsFragment,
        thumbnailsContainer = document.createElement('div'),
        thumbnailsInnerContainer,
        thumbnailContainerTemplate = document.createElement('div'),
        thumbnailContainer,
        thumbnailHeadingTemplate = document.createElement('h4'),
        thumbnailTemplate = document.createElement('img'),
        thumbnailHeading,
        thumbnail,
        selectedThumbnailContainer,
        bigImageContainer = document.createElement('div'),
        bigImageHeading = document.createElement('h1'),
        bigImage = document.createElement('img'),
        searchTitle,
        searchInput,
        i;

    if (itemsCount == 0) {
        return;
    }

    if (selector.substring(0, 1) === '#') {
        container = document.getElementById(selector.substring(1));
    } else if (selector.substring(0, 1) === '.') {
        container = document.getElementsByClassName(selector.substring(1))[0];
    } else {
        container = document.getElementsByTagName(selector)[0];
    }

    // initialize big image container
    bigImageHeading.innerHTML = items[0].title;
    bigImageHeading.style.textAlign = 'center';

    bigImage.src = items[0].url;
    bigImage.width = 350;
    bigImage.style.borderRadius = '15px';

    bigImageContainer.style.cssFloat = 'left';
    bigImageContainer.style.styleFloat = 'left'; //IE
    bigImageContainer.style.width = '350px';
    bigImageContainer.appendChild(bigImageHeading);
    bigImageContainer.appendChild(bigImage);

    // initialize thumbnails container
    searchTitle = document.createElement('div');
    searchTitle.innerHTML = 'Filter';
    searchTitle.style.textAlign = 'center';

    searchInput = document.createElement('input');
    searchInput.type = 'text';
    searchInput.id = 'search';
    searchInput.style.width = '120px';

    // attach search input keyup event
    searchInput.addEventListener('keyup', onSearchInputKeyup);

    thumbnailContainerTemplate.className = 'thumbnail-container';
    thumbnailContainerTemplate.style.paddingLeft = '5px';
    thumbnailHeadingTemplate.style.textAlign = 'center';
    thumbnailHeadingTemplate.style.margin = '0';
    thumbnailTemplate.width = 120;
    thumbnailTemplate.style.borderRadius = '5px';

    populateThumbnails();

    thumbnailsContainer.style.cssFloat = 'left';
    thumbnailsContainer.style.styleFloat = 'left'; //IE
    thumbnailsContainer.style.width = '150px';
    thumbnailsContainer.style.height = '350px';
    thumbnailsContainer.style.overflowY = 'auto';
    thumbnailsContainer.style.marginLeft = '40px';
    thumbnailsContainer.appendChild(searchTitle);
    thumbnailsContainer.appendChild(searchInput);
    thumbnailsContainer.appendChild(thumbnailsInnerContainer);

    container.appendChild(bigImageContainer);
    container.appendChild(thumbnailsContainer);

    function populateThumbnails(data) {
        var itemsCount;

        if (data === undefined) {
            data = items;
        }

        itemsCount = data.length;
        thumbnailsFragment = document.createDocumentFragment();

        for (i = 0; i < itemsCount; i++) {
            thumbnailHeading = thumbnailHeadingTemplate.cloneNode(true);
            thumbnailHeading.innerHTML = data[i].title;

            thumbnail = thumbnailTemplate.cloneNode(true);
            thumbnail.src = data[i].url;

            thumbnailContainer = thumbnailContainerTemplate.cloneNode(true);
            thumbnailContainer.appendChild(thumbnailHeading);
            thumbnailContainer.appendChild(thumbnail);

            // attach thumbnail container events
            thumbnailContainer.addEventListener('mouseover', onThumbnailContainerMouseover);
            thumbnailContainer.addEventListener('mouseout', onThumbnailContainerMouseout);
            thumbnailContainer.addEventListener('click', onThumbnailContainerClick);

            thumbnailsFragment.appendChild(thumbnailContainer);
        }

        thumbnailsInnerContainer = document.createElement('div');
        thumbnailsInnerContainer.appendChild(thumbnailsFragment);
    }

    function onThumbnailContainerMouseover() {
        this.style.background = '#D1CBCE';
    }

    function onThumbnailContainerMouseout() {
        if (selectedThumbnailContainer !== this) {
            this.style.background = 'none';
        }
    }

    function onThumbnailContainerClick() {
        var thumbnailsContainers,
            thumbnailsContainersCount,
            i;

        selectedThumbnailContainer = this;

        bigImageHeading.innerHTML = this.firstElementChild.innerHTML;
        bigImage.src = this.lastElementChild.src;

        thumbnailsContainers = document.querySelectorAll('.thumbnail-container');
        thumbnailsContainersCount = thumbnailsContainers.length;

        for (i = 0; i < thumbnailsContainersCount; i++) {
            if (thumbnailsContainers[i] !== this) {
                thumbnailsContainers[i].style.background = 'none';
            }
        }
    }

    function onSearchInputKeyup() {
        var searchString = searchInput.value,
            result;

        if (searchString !== '') {
            result = searchItems(searchString);
        }

        thumbnailsInnerContainer.parentNode.removeChild(thumbnailsInnerContainer);
        populateThumbnails(result);
        thumbnailsContainer.appendChild(thumbnailsInnerContainer);
    }

    function searchItems(searchString) {
        var result = [],
            title;

        searchString = searchString.toLowerCase();

        for (i = 0; i < itemsCount; i++) {
            title = items[i].title.toLowerCase();

            if (title.indexOf(searchString) > -1) {
                result.push(items[i]);
            }
        }

        return result;
    }
}