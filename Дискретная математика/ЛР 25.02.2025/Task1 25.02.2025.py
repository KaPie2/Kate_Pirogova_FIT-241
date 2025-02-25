#поиск мостов

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

edges = []
components_of_vertexes = [x for x in range(len(matrix))]
for i in range(len(matrix)):
    for j in range(i + 1, len(matrix)):
        if matrix[i][j] != 0:
            edges.append([i, j])

#поиск остова
skeleton = []
for start, end in edges:
    if components_of_vertexes[start] != components_of_vertexes[end]:
        skeleton.append([start, end])
        max_comp = max(components_of_vertexes[start], components_of_vertexes[end]) #наибольший номер компоненты связности
        min_comp = min(components_of_vertexes[start], components_of_vertexes[end]) #наименьший номер компоненты связности
        for i in range(len(components_of_vertexes)):
            if components_of_vertexes[i] == max_comp:
                components_of_vertexes[i] = min_comp

#нахождение мостов с помощью исключения ребер из остова
bridges = []
for i in range(len(skeleton)):
    weight = matrix[skeleton[i][0]][skeleton[i][1]]
    matrix[skeleton[i][0]][skeleton[i][1]] = matrix[skeleton[i][1]][skeleton[i][0]] = 0
    vertexes = list(range(0, len(matrix)))
    components = []
    while vertexes != []:
        data = []
        find_components(vertexes[0])
        vertexes.remove(vertexes[0])
        components.append(data)
    if len(components) != 1:
        bridges.append(skeleton[i])
    matrix[skeleton[i][0]][skeleton[i][1]] = matrix[skeleton[i][1]][skeleton[i][0]] = weight

if len(bridges) > 0:
    print("Мостами являются ребра:")
    for el in bridges:
        print(f"({el[0] + 1}, {el[1] + 1})")
else:
    print("Мостов нет!")
