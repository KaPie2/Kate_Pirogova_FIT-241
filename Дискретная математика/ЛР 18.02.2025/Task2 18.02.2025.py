#алгоритм краскала

def find_components(n):
    data.append(n)
    for i in range(len(matrix)):
        if matrix[n][i] != '0' and (i not in data):
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
    min_weight = 0
    edges = []
    components_of_vertexes = [x for x in range(len(matrix))]
    for i in range(len(matrix)):
        for j in range(i + 1, len(matrix)):
            if matrix[i][j] != 0:
                edges.append([i, j, matrix[i][j]])
    edges = sorted(edges, key=lambda x: x[2])
    for start, end, weight in edges:
        if components_of_vertexes[start] != components_of_vertexes[end]:
            min_weight += weight
            max_comp = max(components_of_vertexes[start], components_of_vertexes[end]) #наибольший номер компоненты связности
            min_comp = min(components_of_vertexes[start], components_of_vertexes[end]) #наименьший номер компоненты связности
            for i in range(len(components_of_vertexes)):
                if components_of_vertexes[i] == max_comp:
                    components_of_vertexes[i] = min_comp
    print(f"Минимальный вес: {min_weight}")
