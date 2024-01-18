let size = 4;
let queensPositions = [];
let hintTaken = false;
let hintsTakenCount = 0; 
let chessBoard = document.getElementById("chess_board");
let puzzleSolved = false;

function createBoard() {
  chessBoard.innerHTML = "";
  queensPositions = [];
  hintTaken = false;
  hintsTakenCount = 0; 

  for (let i = 0; i < size; i++) {
    let row = chessBoard.insertRow(i);
    for (let j = 0; j < size; j++) {
      let backgroundColor =
        (i + j) % 2 === 0 ? "#ccc2b4" : "#8e7b71";

      let cellContent =
        '<div class="box" style="width: 80px; height: 80px; background: ' +
        backgroundColor +
        '"></div>';

      let cell = row.insertCell(j);
      cell.innerHTML = cellContent;

      cell.onclick = (function (rowIndex, colIndex) {
        return function () {
          if (queensPositions.length < size && !hintTaken) {
            placeQueen(rowIndex, colIndex);
          }
        };
      })(i, j);
    }
  }
  const currentBoardSizeElement = document.getElementById("currentBoardSize");
  currentBoardSizeElement.innerText = `Current board size: ${size}x${size}`;

  
}

function changeSize(action) {
  if (action === "increase") {
    size = size === 4 ? 6 : size === 6 ? 8 : 4;
  } else if (action === "decrease") {
    size = size === 8 ? 6 : size === 6 ? 4 : 8;
  }

  createBoard();
}

function placeQueen(row, col) {
    for (let i = 0; i < queensPositions.length; i++) {
      if (
        queensPositions[i].row === row ||
        queensPositions[i].col === col ||
        Math.abs(queensPositions[i].row - row) ===
          Math.abs(queensPositions[i].col - col)
      ) {
        displayIncorrectMoveMessage();
        return;
      }
    }
  
    queensPositions.push({
      row,
      col,
    });
  
    for (let i = 0; i < queensPositions.length; i++) {
      let cell =
        chessBoard.rows[queensPositions[i].row].cells[queensPositions[i].col];
      cell.innerHTML =
        '<span style="color: black; font-size: 36px; display:flex; justify-content: center;">♚</span>';
    }
  
    if (queensPositions.length === size) {
      queensPositions = [];
      if (solve(0)) {
        hintTaken = true;
      }
    }
}
  
function openModal() {
  const modal = document.getElementById("winModal");
  modal.style.display = "block";
}

function closeModal() {
  const modal = document.getElementById("winModal");
    modal.style.display = "none";
    window.location.href = "chooselevel.html";
}
  
  function displayIncorrectMoveMessage() {
    const messageContainer = document.getElementById("messageContainer");
    messageContainer.innerHTML = "Incorrect Move!";
    messageContainer.className = "error";
  

    setTimeout(() => {
      messageContainer.innerHTML = "";
      messageContainer.className = "message-container";
    }, 3000);
  }
  

function solve(row) {
  if (row === size) {
      openModal();
      puzzleSolved = true;
    return true;
  }

  for (let col = 0; col < size; col++) {
    queensPositions.push({
      row,
      col,
    });

    if (isValidPlacement()) {
      if (solve(row + 1)) {
        return true;
      }
    }

    queensPositions.pop();
  }

  return false;
}

function isValidPlacement() {
  for (let i = 0; i < queensPositions.length - 1; i++) {
    for (let j = i + 1; j < queensPositions.length; j++) {
      if (
        queensPositions[i].row === queensPositions[j].row ||
        queensPositions[i].col === queensPositions[j].col ||
        Math.abs(queensPositions[i].row - queensPositions[j].row) ===
          Math.abs(queensPositions[i].col - queensPositions[j].col)
      ) {
        return false;
      }
    }
  }
  return true;
}


function resetBoard() {
  removeHint();
  createBoard();
  hintTaken = false;
  hintsTakenCount = 0; 
}

function canPlaceQueen(row, col) {
  for (let i = 0; i < queensPositions.length; i++) {
    if (
      queensPositions[i].row === row ||
      queensPositions[i].col === col ||
      Math.abs(queensPositions[i].row - row) ===
        Math.abs(queensPositions[i].col - col)
    ) {
      return false;
    }
  }
  return true;
}

function createOverlay(cell, color) {
  let overlay = document.createElement("div");
  overlay.className = "overlay";
  overlay.style.backgroundColor = color;
  cell.appendChild(overlay);
}

function removeOverlay(cell) {
  let overlay = cell.querySelector(".overlay");
  if (overlay) {
    overlay.remove();
  }
}

function takeHint() {
  const messageContainer = document.getElementById("messageContainer");

  if (!hintTaken && hintsTakenCount < 1 && queensPositions.length < size) {
    const hintPosition = findValidHint();
    if (hintPosition) {
      showValidHint(hintPosition.row, hintPosition.col);
      hintTaken = true;
      hintsTakenCount++;
      let hintCell = chessBoard.rows[hintPosition.row].cells[hintPosition.col];
      hintCell.onclick = function () {
        placeQueen(hintPosition.row, hintPosition.col);
        hintTaken = false;
        removeHint();
        hintCell.onclick = null;
      };
      displayMessage("Hint taken successfully!", messageContainer, "success");
    } else {
      displayMessage("No valid hint available.", messageContainer, "error");
    }
  } else if (hintTaken || hintsTakenCount >= 1) {
    displayMessage("Hint is already taken!", messageContainer, "error");
  } else {
    displayMessage("No hint available!", messageContainer, "error");
  }
}

function displayMessage(message, container, type) {
  container.innerHTML = message;
  container.className = type;

  
  setTimeout(() => {
    container.innerHTML = "";
    container.className = "";
  }, 3000);
}

function findValidHint() {
  for (let row = 0; row < size; row++) {
    for (let col = 0; col < size; col++) {
      if (canPlaceQueen(row, col)) {
        return { row, col };
      }
    }
  }
  return null;
}

function showValidHint(row, col) {
  let cell = chessBoard.rows[row].cells[col];
  createOverlay(cell, "rgba(0, 255, 0, 0.5)"); 
}

function removeHint() {
  for (let row = 0; row < size; row++) {
    for (let col = 0; col < size; col++) {
      let cell = chessBoard.rows[row].cells[col];
      removeOverlay(cell);
    }
  }
}

let timeInSeconds = 90; 
let countdownTimer;
const timerElement = document.getElementById("countdownTimer");

function startTimer() {
    countdownTimer = setInterval(function () {
      timeInSeconds--;
  
      if (timeInSeconds > 0) {
        const minutes = Math.floor(timeInSeconds / 60);
        const seconds = timeInSeconds % 60;
        timerElement.innerText = `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;
        
    
      } else {
        clearInterval(countdownTimer);
        if (!puzzleSolved) {
          openTimerModal();
        }
      }
    }, 1000);
  }
  
  
  

function openTimerModal() {
  const modal = document.getElementById("timerModal");

  modal.style.display = "block";
}

function closeTimerModal() {
  const modal = document.getElementById("timerModal");
    modal.style.display = "none";
    window.location.href = "chooselevel.html";
}

function retryTimer() {
  timeInSeconds = 90; 
    closeTimerModal();
    resetBoard();
    startTimer(); 
    
}

function exitTimer() {
  closeModal();
  clearInterval(countdownTimer);
}

window.onload = function () {
    startTimer();
    createBoard();
};

