#алгоритм форда-беллмана
import sys

f = open('test1.txt')
matrix = []
for el in f:
    matrix.append([int(i) for i in el.split()])
vertexes = list(range(0, len(matrix)))

print(f"Введите номер вершины от 1 до {len(matrix)}, с которой хотите начать путь")
from_v = int(input()) - 1

if from_v not in vertexes:
    print("Вершины введены неверно!")
else:
    matrix_of_length = [[sys.maxsize] for _ in range(len(matrix))]
    matrix_of_length[from_v] = [0] * len(matrix)
    for column in range(1, len(matrix)):
        for row in range(len(matrix)):
            if row != from_v:
                elements = []
                for i in range(len(matrix)):
                    if (matrix_of_length[i][column - 1] != sys.maxsize) and (matrix[i][row] != 0):
                        elements.append(matrix_of_length[i][column - 1] + matrix[i][row])
                    else:
                        elements.append(sys.maxsize)
                matrix_of_length[row].append(min(elements))

    for i in range(len(matrix)):
        if i != from_v:
            length = matrix_of_length[i][len(matrix) - 1]
            if length == sys.maxsize:
                length = "бесконечность"
            print(f"Минимальная длина пути из {from_v + 1} вершины до {i + 1}: {length}")
