//
//  SwiftUIView.swift
//  Nqueens
//
//  Created by Enes Saglam on 18.01.2024.
//

import SwiftUI

struct SwiftUIView: View {
    var body: some View {
        NavigationStack {
            VStack(spacing:0, content: {
                Text("WELCOME TO N-QUEENS GAME")
                Image("man")
                    .resizable()
                    .frame(width: 200,height: 200)
                Image("chess")
                    .resizable()
                    .frame(width: 200,height: 200)
                Text("Choose Level:")
                
                Button(action: /*@START_MENU_TOKEN@*/{}/*@END_MENU_TOKEN@*/, label: {
                    NavigationLink {
                        easy()
                    } label: {
                    Text("EASY")
                        .foregroundStyle(.white)
                        .padding(.horizontal,100)
                        .padding()
                        .background(Color.gray
                        ).clipShape(RoundedRectangle(cornerRadius: 10))
                }
                })
                Button(action: {}, label: {
                    NavigationLink {
                        ContentView()
                    } label: {
                    Text("Hard")
                        .foregroundStyle(.white)
                        .padding(.horizontal,100)
                        .padding()
                        .background(Color.gray
                        ).clipShape(RoundedRectangle(cornerRadius: 10))
                }
                }).padding()

            })
        }
    }
}

#Preview {
    SwiftUIView()
}
