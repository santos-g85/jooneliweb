
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

