
//    document.addEventListener('DOMContentLoaded', function () {
//                const dropdownTrigger = document.querySelector('.nav-item.position-static');
//                const megaDropdown = document.querySelector('.mega-dropdown');

//    if (dropdownTrigger && megaDropdown) {
//        let timeout;

//            dropdownTrigger.addEventListener('mouseenter', () => {
//            clearTimeout(timeout);
//                megaDropdown.style.display = 'block';
//                    });

//           dropdownTrigger.addEventListener('mouseleave', () => {
//            timeout = setTimeout(() => {
//            megaDropdown.style.display = 'none';
//                }, 200); // Delay to allow mouse to reach dropdown
//                    });

//          megaDropdown.addEventListener('mouseenter', () => {
//            clearTimeout(timeout);
//            megaDropdown.style.display = 'block';
//                    });

//        megaDropdown.addEventListener('mouseleave', () => {
//        timeout = setTimeout(() => {
//            megaDropdown.style.display = 'none';
//        }, 200);
//                    });
//                }
//     });

/////

//document.addEventListener('DOMContentLoaded', function () {
//    const navLinks = document.querySelectorAll('.navbar-nav .nav-link');
//    const containerFluid = document.querySelector('.container-fluid');

//    navLinks.forEach(link => {
//        link.addEventListener('mouseenter', function () {
//            containerFluid.style.backgroundColor = 'white';
//        });

//        link.addEventListener('mouseleave', function () {
//            // Only change back if not hovering over dropdown
//            if (!document.querySelector('.mega-dropdown:hover')) {
//                containerFluid.style.backgroundColor = 'white';
//            }
//        });
//    });

//    // Also handle dropdown hover
//    const megaDropdown = document.querySelector('.mega-dropdown');
//    if (megaDropdown) {
//        megaDropdown.addEventListener('mouseleave', function () {
//            containerFluid.style.backgroundColor = '';
//        });
//    }
//});



// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    const dropdownTrigger = document.querySelector('.nav-item.position-static');
    const megaDropdown = document.querySelector('.mega-dropdown');

    if (dropdownTrigger && megaDropdown) {
        let timeout;

        dropdownTrigger.addEventListener('mouseenter', () => {
            clearTimeout(timeout);
            megaDropdown.style.display = 'block';
        });

        dropdownTrigger.addEventListener('mouseleave', () => {
            timeout = setTimeout(() => {
                megaDropdown.style.display = 'none';
            }, 200); // Delay to allow mouse to reach dropdown
        });

        megaDropdown.addEventListener('mouseenter', () => {
            clearTimeout(timeout);
            megaDropdown.style.display = 'block';
        });

        megaDropdown.addEventListener('mouseleave', () => {
            timeout = setTimeout(() => {
                megaDropdown.style.display = 'none';
            }, 200);
        });
    }
});


//document.addEventListener('DOMContentLoaded', function () {
//    const navItem = document.querySelectorAll('.navbar-collapse .navbar-nav .my-list .nav-link');
//    const containerFluid = document.querySelector('.custom-header');
//    const customtouch = document.querySelector('.custom-header .touch-custom')
//    // Ensure the container has a smooth transition for background color
//    containerFluid.style.transition = 'background-color 0.3s ease'; // Smooth transition for background color

//    navItem.forEach(link => {
//        link.style.transition = 'color 0.2s ease'; // Smooth transition for text color
//    });

//    let isHoveringNavLink = false; // Track if the mouse is on a nav link


//    navItem.forEach(link => {
//        link.addEventListener('mouseenter', function () {
//            isHoveringNavLink = true;
//            containerFluid.style.backgroundColor = 'white'; // Change to white on hover
//            link.style.color = 'black';
//            customtouch.classList.remove('btn-outline-light');
//            customtouch.classList.add('btn-outline-danger');
//        });

//        link.addEventListener('mouseleave', function () {
//            isHoveringNavLink = false;

//            // Only reset if not hovering over mega-dropdown
//            setTimeout(() => {
//                if (!document.querySelector('.mega-dropdown:hover') && !isHoveringNavLink) {
//                    containerFluid.style.backgroundColor = ''; // Reset to original color smoothly
//                    customtouch.classList.remove('btn-outline-danger');
//                    customtouch.classList.add('btn-outline-light');
//                    navItem.forEach(link => {
//                        link.style.color = ''; // Reset text color smoothly
//                    });
//                }
//            }, 200); // Delay to allow for smooth transition when mouse leaves
//        });
//    });

//    // Also handle dropdown hover
//    const megaDropdown = document.querySelector('.mega-dropdown');
//    if (megaDropdown) {
//        megaDropdown.addEventListener('mouseenter', function () {
//            isHoveringNavLink = false; // Prevent background reset when hovering over dropdown
//        });

//        megaDropdown.addEventListener('mouseleave', function () {
//            // Reset background color only if the nav link isn't being hovered
//            setTimeout(() => {
//                if (!isHoveringNavLink) {
//                    containerFluid.style.backgroundColor = ''; // Reset to original color smoothly
//                    customtouch.classList.remove('btn-outline-danger');
//                    customtouch.classList.add('btn-outline-light');
//                    navItem.forEach(link => {
//                        link.style.color = ''; // Reset text color smoothly
//                    });
//                }
//            }, 300); // Delay to allow for smooth transition when mouse leaves
//        });
//    }
//});


//document.addEventListener('DOMContentLoaded', function () {
//    const dropdownTrigger = document.querySelector('.nav-item.position-static');
//    const megaDropdown = document.querySelector('.mega-dropdown');
//    const navItems = document.querySelectorAll('.navbar-collapse .navbar-nav .my-list .nav-link');
//    const header = document.querySelector('.custom-header');
//    const button = document.querySelector('.custom-header .touch-custom');

//    let isHoveringNavLink = false;
//    let timeout;

//    if (dropdownTrigger && megaDropdown) {
//        dropdownTrigger.addEventListener('mouseenter', () => {
//            clearTimeout(timeout);
//            megaDropdown.style.display = 'block';
//        });

//        dropdownTrigger.addEventListener('mouseleave', () => {
//            timeout = setTimeout(() => {
//                megaDropdown.style.display = 'none';
//            }, 500);
//        });

//        megaDropdown.addEventListener('mouseenter', () => {
//            clearTimeout(timeout);
//            megaDropdown.style.display = 'block';
//        });

//        megaDropdown.addEventListener('mouseleave', () => {
//            timeout = setTimeout(() => {
//                megaDropdown.style.display = 'none';
//                resetStyles();
//            }, 500);
//        });
//    }

//    navItems.forEach(link => {
//        link.addEventListener('mouseenter', function () {
//            isHoveringNavLink = true;
//            header.style.backgroundColor = 'white';
//            link.style.color = 'black';
//            button.classList.remove('btn-outline-light');
//            button.classList.add('btn-outline-danger');
//        });

//        link.addEventListener('mouseleave', function () {
//            isHoveringNavLink = false;
//            setTimeout(() => {
//                if (!megaDropdown?.matches(':hover') && !isHoveringNavLink) {
//                    resetStyles();
//                }
//            }, 500);
//        });
//    });

//    function resetStyles() {
//        header.style.backgroundColor = '';
//        button.classList.remove('btn-outline-danger');
//        button.classList.add('btn-outline-light');
//        navItems.forEach(link => {
//            link.style.color = '';
//        });
//    }
//});


document.addEventListener('DOMContentLoaded', function () {
    const dropdownTrigger = document.querySelector('.nav-item.position-static');
    const megaDropdown = document.querySelector('.mega-dropdown');
    const navItems = document.querySelectorAll('.navbar-collapse .navbar-nav .my-list .nav-link');
    const header = document.querySelector('.custom-header');
    const button = document.querySelector('.custom-header .touch-custom');

    let isHoveringNavLink = false;
    let timeout;

    if (dropdownTrigger && megaDropdown) {
        dropdownTrigger.addEventListener('mouseenter', () => {
            clearTimeout(timeout);
            megaDropdown.style.display = 'block';
        });

        dropdownTrigger.addEventListener('mouseleave', () => {
            timeout = setTimeout(() => {
                megaDropdown.style.display = 'none';
            }, 500);
        });

        megaDropdown.addEventListener('mouseenter', () => {
            clearTimeout(timeout);
            megaDropdown.style.display = 'block';
        });

        megaDropdown.addEventListener('mouseleave', () => {
            timeout = setTimeout(() => {
                megaDropdown.style.display = 'none';
                resetStyles();
            }, 500);
        });
    }

    navItems.forEach(link => {
        link.addEventListener('mouseenter', function () {
            isHoveringNavLink = true;
            header.style.backgroundColor = 'white';

            // Set all nav link colors to black
            navItems.forEach(item => {
                item.style.color = 'black';
            });

            button.classList.remove('btn-outline-light');
            button.classList.add('btn-outline-danger');
        });

        link.addEventListener('mouseleave', function () {
            isHoveringNavLink = false;
            setTimeout(() => {
                if (!megaDropdown?.matches(':hover') && !isHoveringNavLink) {
                    resetStyles();
                }
            }, 500);
        });
    });

    function resetStyles() {
        header.style.backgroundColor = '';
        button.classList.remove('btn-outline-danger');
        button.classList.add('btn-outline-light');

        // Reset all nav link colors
        navItems.forEach(link => {
            link.style.color = '';
        });
    }
});
