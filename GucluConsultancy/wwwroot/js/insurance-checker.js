const yesInsurance = document.querySelector("#yes-insurance");
const noInsurance = document.querySelector("#no-insurance");

if (yesInsurance)
{
  checkDisplayInsurance();

  yesInsurance.addEventListener("input", function (event)
  {
    checkDisplayInsurance();
  });

  noInsurance.addEventListener("input", function (event)
  {
    checkDisplayInsurance();
  });
}

function checkDisplayInsurance()
{
  const insuranceInputWrapper = document.querySelector(".insurance-input");
  const insuranceInput = document.querySelector(".insurance-input input");

  if (yesInsurance.checked)
  {
    insuranceInputWrapper.style.display = "block";
    insuranceInput.setAttribute("required", "required");
  }
  else
  {
    insuranceInputWrapper.style.display = "none";
    insuranceInput.removeAttribute("required");
  }
}