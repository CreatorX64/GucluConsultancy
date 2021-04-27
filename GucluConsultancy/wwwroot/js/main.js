const loaderDiv = document.querySelector(".loader");

// Keys: spacebar (32), pageup (33), pagedown (34), end (35), home (36),
// left(37), up(38), right(39), down(40)
const keys = { 32: 1, 33: 1, 34: 1, 35: 1, 36: 1, 37: 1, 38: 1, 39: 1, 40: 1 };

// Modern Chrome requires { passive: false } when adding event.
let supportsPassive = false;
try
{
  window.addEventListener(
    "test",
    null,
    Object.defineProperty({}, 'passive',
      {
        get: function ()
        {
          supportsPassive = true;
        }
      })
  );
} catch (e) { }

let wheelOptions = supportsPassive ? { passive: false } : false;
let wheelEvent = 'onwheel' in document.createElement('div') ? 'wheel' : 'mousewheel';

// Disable scrolling while loading animation is running.
loaderDiv.addEventListener("animationstart", () =>
{
  disableScroll();
});

// Enable scrolling once loading animation ends.
loaderDiv.addEventListener("animationend", () =>
{
  enableScroll();
});

// Disable submit button if information button is submitted.
const infoSubmitButton = document.querySelector(".information-form .button-action");
if (infoSubmitButton)
{
  const infoForm = document.querySelector(".information-form");

  infoForm.addEventListener("submit", e =>
  {
    if ($(".information-form").valid())
    {
      infoSubmitButton.textContent = "Lütfen bekleyin...";
      infoSubmitButton.disabled = true;
    }
  });
}


function preventDefault(e)
{
  e.preventDefault();
}


function preventDefaultForScrollKeys(e)
{
  if (keys[e.keyCode])
  {
    //preventDefault(e);
    e.preventDefault();
    return false;
  }
}


function disableScroll()
{
  window.addEventListener('DOMMouseScroll', preventDefault, false); // older FF
  window.addEventListener(wheelEvent, preventDefault, wheelOptions); // modern desktop
  window.addEventListener('touchmove', preventDefault, wheelOptions); // mobile
  window.addEventListener('keydown', preventDefaultForScrollKeys, false);
}


function enableScroll()
{
  window.removeEventListener('DOMMouseScroll', preventDefault, false);
  window.removeEventListener(wheelEvent, preventDefault, wheelOptions);
  window.removeEventListener('touchmove', preventDefault, wheelOptions);
  window.removeEventListener('keydown', preventDefaultForScrollKeys, false);
}


function swal(text, type)
{
  Swal.fire(text, "", type);
}