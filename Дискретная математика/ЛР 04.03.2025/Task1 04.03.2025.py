#алгоритм дейкстра
import sys

f = open('test1.txt')
matrix = []
for el in f:
    matrix.append([int(i) for i in el.split()])
vertexes = list(range(0, len(matrix)))


print(f"Введите номер вершины от 1 до {len(matrix)}, с которой хотите начать путь")
from_v = int(input()) - 1
print(f"Введите номер вершины от 1 до {len(matrix)}, в которой хотите закончить путь")
to_v = int(input()) - 1
if (from_v not in vertexes) or (to_v not in vertexes):
    print("Вершины введены неверно!")
else:
    value_column = [sys.maxsize] * len(matrix)
    value_row = [sys.maxsize] * len(matrix)
    way_vertexes = [from_v]
    value_column[from_v] = 0
    for x in range(len(matrix)):
        i = way_vertexes[x]
        if i == to_v:
            break
        else:
            curr_row = [sys.maxsize] * len(matrix)
            for j in range(len(matrix)):
                if matrix[i][j] != 0 and j not in way_vertexes:
                    curr_row[j] = min(matrix[i][j] + value_column[i], value_row[j])
                    value_row[j] = min(curr_row[j], value_row[j])
                elif matrix[i][j] == 0 and j not in way_vertexes:
                    curr_row[j] = value_row[j]
            a = min(curr_row)
            ind = curr_row.index(a)
            way_vertexes.append(ind)
            value_column[way_vertexes[-1]] = min(curr_row)
    print(f"Наименьшее расстояние: {value_column[to_v]}")
