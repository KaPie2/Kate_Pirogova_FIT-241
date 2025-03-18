# Задание №18
# Дана волейбольная сетка с заданным количеством ячеек. 
# Определить максимальное число веревок, составляющих ее ребра, которые можно разрезать так, чтобы она не распалась.

print("Введите размеры сетки через пробел (два числа): ")
n, m = [int(el) for el in input().split()]
vertexes = (n + 1) * (m + 1)

matrix = [[0 for _ in range(vertexes)] for _ in range(vertexes)]

# Создание матрицы смежности (не симметрична, только верхний треугольник) и поиск ребер
edges = []
for i in range(vertexes):
    for j in range(i + 1, vertexes):
        if (j - i == 1 and (i + 1) % (m + 1) != 0) or (j - i == m + 1):
            matrix[i][j] = 1
            edges.append([i, j])

# Поиск остова
components_of_vertexes = [x for x in range(vertexes)]
skeleton = []
for start, end in edges:
    if components_of_vertexes[start] != components_of_vertexes[end]:
        skeleton.append([start, end])
        max_comp = max(components_of_vertexes[start], components_of_vertexes[end]) # Наибольший номер компоненты связности
        min_comp = min(components_of_vertexes[start], components_of_vertexes[end]) # Наименьший номер компоненты связности
        for i in range(len(components_of_vertexes)):
            if components_of_vertexes[i] == max_comp:
                components_of_vertexes[i] = min_comp

result = len(edges) - len(skeleton)
print(f"Максимальное число веревок, которые можно разрезать так, чтобы она не распалась: {result}")
