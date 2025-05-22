document.addEventListener('DOMContentLoaded', function () {
    // Элементы DOM
    const stationSelection = document.getElementById('stationSelection');
    const timeSelection = document.getElementById('timeSelection');
    const nextToTimeBtn = document.getElementById('nextToTime');
    const timeSelectionContainer = document.getElementById('timeSelectionContainer');
    const selectedStationsList = document.getElementById('selectedStationsList');

    let selectedStations = [];
    let stationTimes = {};

    // 1. Инициализация выбора станций
    initStationSelection();

    // 2. Обработчик кнопки "Next"
    nextToTimeBtn.addEventListener('click', function () {
        if (selectedStations.length === 0) {
            alert('Please select at least one station');
            return;
        }

        // Генерируем блоки выбора времени
        generateTimeSelectionBlocks();

        // Переключаем шаги
        stationSelection.classList.remove('active');
        timeSelection.classList.add('active');
    });

    // 3. Функция инициализации выбора станций
    function initStationSelection() {
        document.querySelectorAll('.station').forEach(station => {
            station.addEventListener('click', function () {
                const stationId = this.getAttribute('data-id');
                const stationName = this.textContent;

                const index = selectedStations.findIndex(s => s.id === stationId && s.name === stationName);

                if (index === -1) {
                    selectedStations.push({ id: stationId, name: stationName });
                    this.classList.add('selected');
                } else {
                    selectedStations.splice(index, 1);
                    this.classList.remove('selected');
                }

                updateSelectedStationsList();
            });
        });
    }

    // 4. Обновление списка выбранных станций
    function updateSelectedStationsList() {
        selectedStationsList.innerHTML = '';

        if (selectedStations.length === 0) {
            selectedStationsList.innerHTML = '<p>No stations selected</p>';
            return;
        }

        selectedStations.forEach((station, index) => {
            const stationElement = document.createElement('div');
            stationElement.className = 'selected-station';
            stationElement.innerHTML = `
                ${station.name}
                <button class="remove-station" data-index="${index}">×</button>
            `;
            selectedStationsList.appendChild(stationElement);
        });

        // Обработчики для кнопок удаления
        document.querySelectorAll('.remove-station').forEach(btn => {
            btn.addEventListener('click', function () {
                const index = parseInt(this.getAttribute('data-index'));
                const stationId = selectedStations[index].id;

                document.querySelectorAll(`.station[data-id="${stationId}"]`).forEach(station => {
                    if (station.textContent === selectedStations[index].name) {
                        station.classList.remove('selected');
                    }
                });

                selectedStations.splice(index, 1);
                updateSelectedStationsList();
            });
        });
    }

    // 5. Генерация блоков выбора времени
    function generateTimeSelectionBlocks() {
        timeSelectionContainer.innerHTML = '';
        stationTimes = {};

        selectedStations.forEach(station => {
            const stationBlock = document.createElement('div');
            stationBlock.className = 'station-time-block';
            stationBlock.innerHTML = `
                <h4>${station.name}</h4>
                <div class="time-options" id="timeOptions_${station.id}"></div>
                <div class="duration-controls">
                    <span>Duration:</span>
                    <span class="duration-display" id="durationDisplay_${station.id}">30 min</span>
                    <div class="duration-buttons">
                        <button class="duration-btn" data-station="${station.id}" data-change="-30">-30m</button>
                        <button class="duration-btn" data-station="${station.id}" data-change="+30">+30m</button>
                    </div>
                </div>
                <input type="hidden" id="selectedTime_${station.id}" value="">
                <input type="hidden" id="duration_${station.id}" value="30">
            `;

            timeSelectionContainer.appendChild(stationBlock);

            // Инициализация данных о времени
            stationTimes[station.id] = {
                name: station.name,
                startTime: null,
                duration: 30
            };

            // Генерация доступных временных слотов
            generateTimeOptions(station.id);

            // Обработчики для кнопок продолжительности
            document.querySelectorAll(`.duration-btn[data-station="${station.id}"]`).forEach(btn => {
                btn.addEventListener('click', function () {
                    const change = parseInt(this.dataset.change);
                    const durationDisplay = document.getElementById(`durationDisplay_${station.id}`);
                    const durationInput = document.getElementById(`duration_${station.id}`);

                    let newDuration = parseInt(durationInput.value) + change;

                    // Проверка ограничений (30min - 6 hours)
                    if (newDuration < 30) newDuration = 30;
                    if (newDuration > 360) newDuration = 360;

                    durationInput.value = newDuration;
                    stationTimes[station.id].duration = newDuration;

                    // Обновление отображения
                    const hours = Math.floor(newDuration / 60);
                    const minutes = newDuration % 60;
                    durationDisplay.textContent = hours > 0
                        ? `${hours}h ${minutes > 0 ? minutes + 'm' : ''}`.trim()
                        : `${minutes}m`;
                });
            });
        });
    }

    // 6. Генерация доступных временных слотов
    function generateTimeOptions(stationId) {
        const timeOptionsContainer = document.getElementById(`timeOptions_${stationId}`);
        timeOptionsContainer.innerHTML = '';

        // Здесь должен быть запрос к API для получения занятых слотов
        // Для примера используем фиктивные данные:
        const bookedSlots = [
            { start: '14:00', end: '15:30' },
            { start: '16:00', end: '17:00' }
        ];

        // Генерация слотов с 10:00 до 22:00 с шагом 30 минут
        for (let hour = 10; hour < 22; hour++) {
            for (let minute = 0; minute < 60; minute += 30) {
                const timeString = `${hour.toString().padStart(2, '0')}:${minute.toString().padStart(2, '0')}`;

                // Проверка доступности слота
                const isAvailable = !bookedSlots.some(slot => {
                    return timeString >= slot.start && timeString < slot.end;
                });

                if (isAvailable) {
                    const timeOption = document.createElement('div');
                    timeOption.className = 'time-option';
                    timeOption.textContent = timeString;
                    timeOption.dataset.time = timeString;

                    timeOption.addEventListener('click', function () {
                        // Снимаем выделение с других вариантов
                        document.querySelectorAll(`#timeOptions_${stationId} .time-option`).forEach(opt => {
                            opt.classList.remove('selected');
                        });

                        // Выделяем текущий вариант
                        this.classList.add('selected');

                        // Сохраняем выбранное время
                        document.getElementById(`selectedTime_${stationId}`).value = this.dataset.time;
                        stationTimes[stationId].startTime = this.dataset.time;
                    });

                    timeOptionsContainer.appendChild(timeOption);
                }
            }
        }
    }
});