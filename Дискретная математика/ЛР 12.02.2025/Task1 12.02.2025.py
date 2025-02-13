def find_components(n):
    data.append(n)
    for i in range(0, len(matrix)):
        if matrix[n][i] == '1' and (i not in data):
            vertexes.remove(i)
            find_components(i)

f = open('test1.txt')
matrix = []
for el in f:
    matrix.append(el.split())
vertexes = list(range(0, len(matrix)))
components = []
while vertexes != []:
    data = []
    find_components(vertexes[0])
    vertexes.remove(vertexes[0])
    components.append(data)
print(f'Количество компонент связности графа: {len(components)}')
