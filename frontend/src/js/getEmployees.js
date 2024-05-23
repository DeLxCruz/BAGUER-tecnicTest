async function fetchEmployees() {
  try {
    const response = await axios.get("https://randomuser.me/api/?results=10", {
      params: {
        _limit: 10,
      },
    });
    return response.data.results;
  } catch (error) {
    throw new Error("Error fetching employees: " + error);
  }
}

function fillEmployeesTable(employees) {
  const tableBody = document.querySelector(".table tbody");

  employees.forEach((employee, index) => {
    const row = document.createElement("tr");

    // Añadir la posición del empleado
    const positionCell = document.createElement("td");
    positionCell.textContent = index + 1;
    row.appendChild(positionCell);

    const avatarCell = document.createElement("td");
    const flexContainer = document.createElement("div");
    flexContainer.classList.add("flex", "items-center", "gap-3");

    const avatarDiv = document.createElement("div");
    avatarDiv.classList.add("avatar");

    const maskDiv = document.createElement("div");
    maskDiv.classList.add("mask", "mask-squircle", "w-12", "h-12");

    const img = document.createElement("img");
    img.setAttribute("src", employee.picture.thumbnail);
    img.setAttribute("alt", employee.name.first);

    maskDiv.appendChild(img);
    avatarDiv.appendChild(maskDiv);

    const infoDiv = document.createElement("div");

    const nameDiv = document.createElement("div");
    nameDiv.classList.add("font-bold");
    nameDiv.textContent = `${employee.name.first} ${employee.name.last}`;

    const countryDiv = document.createElement("div");
    countryDiv.classList.add("text-sm", "opacity-50");
    countryDiv.textContent = employee.location.country;

    infoDiv.appendChild(nameDiv);
    infoDiv.appendChild(countryDiv);

    flexContainer.appendChild(avatarDiv);
    flexContainer.appendChild(infoDiv);

    avatarCell.appendChild(flexContainer);
    row.appendChild(avatarCell);

    const lastNameCell = document.createElement("td");
    lastNameCell.textContent = employee.name.last;
    row.appendChild(lastNameCell);

    const detailCell = document.createElement("td");
    const detailButton = document.createElement("button");
    detailButton.textContent = "Detalle";
    detailButton.classList.add("btn");

    detailButton.addEventListener("click", () => openEmployeeModal(employee));
    detailCell.appendChild(detailButton);
    row.appendChild(detailCell);

    tableBody.appendChild(row);
  });
}

function openEmployeeModal(employee) {
  const modal = document.getElementById("employeeModal");

  // Llenar el modal con la información del empleado
  modal.querySelector(
    ".employee-name"
  ).textContent = `${employee.name.first} ${employee.name.last}`;
  modal.querySelector(".employee-gender").textContent = employee.gender;
  modal
    .querySelector(".employee-avatar")
    .setAttribute("src", employee.picture.large);

  modal.showModal();
}

async function displayEmployees() {
  try {
    const employees = await fetchEmployees();
    fillEmployeesTable(employees);
    console.log(employees);
  } catch (error) {
    console.error(error);
  }
}

displayEmployees();
