import SwiftUI

struct ContentView: View {
    @State private var gameSolved = false

    @State private var boardSize = 4
    @State private var queens = Array(repeating: Array(repeating: false, count: 4), count: 4)
    @State private var errorMessage = ""
    @State private var timeRemaining = 60
    @State private var gameWon = false

    let timer = Timer.publish(every: 1, on: .main, in: .common).autoconnect()
    @State private var timerActive = true
    var body: some View {
        NavigationStack {
            VStack(spacing:0) {
                ForEach(0..<boardSize, id: \.self) { row in
                    HStack(spacing:0) {
                        ForEach(0..<boardSize, id: \.self) { column in
                            SquareView(isBlack: (row + column) % 2 == 0, hasQueen: queens[row][column])
                                .onTapGesture {
                                    placeQueen(atRow: row, column: column)
                                }
                        }
                    }
                }
                
                if !errorMessage.isEmpty {
                    Text(errorMessage)
                        .foregroundColor(.red)
                }
                
                Text("Current Board Size: \(boardSize)")
                if gameWon {
                    Text("Congratulations! You have solved the puzzle!")
                        .foregroundColor(.green)
                        .font(.headline)
                }

                Button {
                    if boardSize < 6{
                        boardSize += 1
                        queens = resizeArray(queens, to: boardSize)
                    }
                } label: {
                    Text("Increase board Size")
                        .foregroundStyle(.black)
                        .padding()
                        .background {
                            Color.gray.opacity(0.23)
                        }
                        .clipShape(RoundedRectangle(cornerRadius: 11.0))
                }
                .padding()
                Button {
                    if boardSize > 3{
                        boardSize -= 1
                        queens = resizeArray(queens, to: boardSize)
                    }
                } label: {
                    Text("Decrease board Size")
                        .foregroundStyle(.black)
                        .padding()
                        .background {
                            Color.gray.opacity(0.23)
                        }
                        .clipShape(RoundedRectangle(cornerRadius: 11.0))
                }.padding()
                Text("Time Remaining: \(timeRemaining)")
                    .onReceive(timer) { _ in
                        if timeRemaining > 0 && timerActive {
                            timeRemaining -= 1
                        }
                    }
                
                Button("Restart") {
                    restartGame()
                }
                .padding()
                .background(Color.green)
                .foregroundColor(.white)
                .clipShape(RoundedRectangle(cornerRadius: 11.0))
            }
            .disabled(timeRemaining == 0 || gameSolved)
            .alert(isPresented: $gameSolved) {
                Alert(title: Text("Congratulations!"), message: Text("You have solved the puzzle!"), dismissButton: .default(Text("OK")) {
                    restartGame()
                })
            }
        }
    }
    
    
    func placeQueen(atRow row: Int, column: Int) {
        if isValidMove(row: row, column: column) {
            queens[row][column] = true
            errorMessage = ""
            checkIfGameIsSolved()
        } else {
            errorMessage = "Incorrect move"
        }
    }
    func resizeArray(_ array: [[Bool]], to newSize: Int) -> [[Bool]] {
        var newArray = array
        if newSize > array.count {
            // Add new rows
            newArray.append(contentsOf: Array(repeating: Array(repeating: false, count: newSize), count: newSize - array.count))

            // Extend existing rows
            for i in 0..<newArray.count {
                newArray[i].append(contentsOf: Array(repeating: false, count: newSize - newArray[i].count))
            }
        }
        return newArray
    }
    func restartGame() {
           timeRemaining = 60
           timerActive = true
           queens = Array(repeating: Array(repeating: false, count: boardSize), count: boardSize)
           errorMessage = ""
        gameWon = false

       }
    func checkIfGameIsSolved() {
        let totalQueens = queens.flatMap { $0 }.filter { $0 }.count
        if totalQueens == boardSize {
           
            gameSolved = true
            gameWon = true
        }
    }

    func isValidMove(row: Int, column: Int) -> Bool {
        // Check the column
        for i in 0..<boardSize {
            if queens[i][column] {
                return false
            }
        }
        
        for i in 0..<boardSize {
            if queens[row][i] {
                return false
            }
        }
        
        var i = row
        var j = column
        while i >= 0 && j >= 0 {
            if queens[i][j] {
                return false
            }
            i -= 1
            j -= 1
        }
        
        i = row
        j = column
        while i < boardSize && j < boardSize {
            if queens[i][j] {
                return false
            }
            i += 1
            j += 1
        }
        
        i = row
        j = column
        while i >= 0 && j < boardSize {
            if queens[i][j] {
                return false
            }
            i -= 1
            j += 1
        }
        
        i = row
        j = column
        while i < boardSize && j >= 0 {
            if queens[i][j] {
                return false
            }
            i += 1
            j -= 1
        }
        
        return true
    }
    
    
    struct SquareView: View {
        var isBlack: Bool
        var hasQueen: Bool
        
        var body: some View {
            ZStack {
                Rectangle()
                    .foregroundColor(isBlack ? Color.gray : Color.white)
                    .frame(width: 65, height: 65)
                    .border(Color.black, width: 1)
                if hasQueen {
                    Image("quen")
                        .resizable()
                        .frame(width: 30,height: 35)
                        .font(.largeTitle)
                        .foregroundColor(.red)
                }
            }
        }
    }
}

#Preview{
    ContentView()
}


