let size = 4;
let queensPositions = [];
let chessBoard = document.getElementById("chess_board");
function createBoard() {
  chessBoard.innerHTML = "";
  queensPositions = [];

  for (let i = 0; i < size; i++) {
    let row = chessBoard.insertRow(i);
    for (let j = 0; j < size; j++) {
      let backgroundColor = (i + j) % 2 === 0 ? "#ccc2b4" : "#8e7b71";

      let cellContent =
        '<div class="box" style="width: 80px; height: 80px; background: ' +
        backgroundColor +
        '"></div>';

      let cell = row.insertCell(j);
      cell.innerHTML = cellContent;

      cell.onclick = (function (rowIndex, colIndex) {
        return function () {
          if (queensPositions.length < size) {
            placeQueen(rowIndex, colIndex);
          }
        };
      })(i, j);
    }
  }
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
      '<span style="  color: white; font-size: 36px; display:flex; justify-content: center; padding-top: 13px">♛</span>';
  }

  if (queensPositions.length === size) {
    queensPositions = [];
    if (solve(0)) {
      placeQueensOnBoard();
    } else {
    }
  }
}

function solve(row) {
  if (row === size) {
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

function placeQueensOnBoard() {
  for (let i = 0; i < queensPositions.length; i++) {
    let cell =
      chessBoard.rows[queensPositions[i].row].cells[queensPositions[i].col];
    cell.innerHTML = '<span class="queen">♛</span>';
  }
}

function resetBoard() {
  createBoard();
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

window.onload = createBoard;
