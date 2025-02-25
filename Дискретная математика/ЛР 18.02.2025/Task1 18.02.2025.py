#Алгоритм прима

import sys

def find_components(n):
    data.append(n)
    for i in range(len(matrix)):
        if matrix[n][i] != 0 and (i not in data):
            vertexes.remove(i)
            find_components(i)

f = open('test1.txt')
matrix = []
for el in f:
    matrix.append([int(i) for i in el.split()])
vertexes = list(range(0, len(matrix)))
components = []
while vertexes != []:
    data = []
    find_components(vertexes[0])
    vertexes.remove(vertexes[0])
    components.append(data)
cnt_components = len(components)
if cnt_components > 1:
    print("Граф не связный!")
else:
    vertexes = list(range(0, len(matrix)))
    print(f"Введите номер любой вершины от 1 до {len(matrix)}")
    vertex = int(input()) - 1
    data_vertexes_tree = [vertexes[vertex]]
    min_weight = 0
    while len(data_vertexes_tree) != len(matrix):
        min_value = sys.maxsize #для поиска наименьшего из строк
        for i in range(len(data_vertexes_tree)):
            row = data_vertexes_tree[i]
            matrix_row_without_null = [matrix[row][x] for x in range(len(matrix[row])) if matrix[row][x] != 0 and (x not in data_vertexes_tree)]
            if matrix_row_without_null != []:
                min_in_row = min(matrix_row_without_null)
                if min_in_row < min_value:
                    min_value = min_in_row
                    add_vertex = [j for j in range(len(matrix[row])) if j not in data_vertexes_tree and matrix[row][j] == min_value][0]
        min_weight += min_value
        data_vertexes_tree.append(add_vertex)
print(f"Минимальный вес: {min_weight}")
