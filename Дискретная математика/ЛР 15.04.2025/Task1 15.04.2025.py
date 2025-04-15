# алгоритм литтла

import sys

f = open('test1.txt')
matrix = []
for el in f:
    matrix.append([sys.maxsize if i == "-0" else int(i) for i in el.split()])
vertexes_row = "".join(map(str, list(range(0, len(matrix)))))
vertexes_col = "".join(map(str, list(range(0, len(matrix)))))

score = 0
while len(matrix) > 2:
    del_row = 0
    del_col = 0
    ratio = 0
    for row in range(len(vertexes_row)):
        min_el = min(matrix[row])
        score += min_el
        for col in range(len(vertexes_col)):
            if matrix[row][col] != sys.maxsize:
                matrix[row][col] -= min_el

    for col in range(len(vertexes_col)):
        min_el = min([matrix[i][col] for i in range(len(vertexes_row))])
        score += min_el
        for row in range(len(vertexes_row)):
            if matrix[row][col] != sys.maxsize:
                matrix[row][col] -= min_el

    for row in range(len(vertexes_row)):
        for col in range(len(vertexes_col)):
            if matrix[row][col] == 0:
                min_in_row = sorted(matrix[row])[1]
                min_in_col = sorted([matrix[i][col] for i in range(len(vertexes_row))])[1]
                if (min_in_col + min_in_row) > ratio:
                    del_col = vertexes_col[col]
                    del_row = vertexes_row[row]
                    ratio = min_in_col + min_in_row

    new_matrix = [row[:vertexes_col.find(del_col)] + row[vertexes_col.find(del_col) + 1:] for i, row in
                  enumerate(matrix) if i != vertexes_row.find(del_row)]
    matrix = new_matrix.copy()
    vertexes_row = vertexes_row.replace(del_row, "")
    vertexes_col = vertexes_col.replace(del_col, "")
    print(del_row, del_col, score, '\n')

    for row in range(len(vertexes_row)):
        if sys.maxsize not in matrix[row]:
            for col in range(len(vertexes_col)):
                elem_col = [matrix[i][col] for i in range(len(vertexes_row))]
                if sys.maxsize not in elem_col:
                    matrix[row][col] = sys.maxsize

for i in range(len(vertexes_row)):
    if 0 not in matrix[i]:
        for row in range(len(vertexes_row)):
            min_el = min(matrix[row])
            score += min_el
            for col in range(len(vertexes_col)):
                if matrix[row][col] != sys.maxsize:
                    matrix[row][col] -= min_el

        for col in range(len(vertexes_col)):
            min_el = min([matrix[i][col] for i in range(len(vertexes_row))])
            score += min_el
            for row in range(len(vertexes_row)):
                if matrix[row][col] != sys.maxsize:
                    matrix[row][col] -= min_el
print(f"Нижняя оценка: {score}")
