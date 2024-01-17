var size = 4;

createTable();

function createTable() {
  for (var r = 0; r < size; r++) {
    document.write("<tr>");
    for (var c = 0; c < size; c++) {
      id = r * size + c;
      document.write("<td id=" + id + ' onclick="placeq(this);">');
      var backgroundColor = (r + c) % 2 === 0 ? "#ccc2b4;" : "#8e7b71";

      document.write(
        '<div class="box" style="width: 100px; height: 100px; background: ' +
          backgroundColor +
          '"></div>'
      );
    }
    document.write("</tr>");
  }
}
